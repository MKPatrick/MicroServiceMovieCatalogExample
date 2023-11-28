using FluentValidation.AspNetCore;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MovieStreaming.Application.Configuration;
using MovieStreaming.Application.Helper;
using MovieStreaming.Application.Messaging;
using MovieStreaming.Domain.Contracts;
using MovieStreaming.Infrastructure.Data;
using MovieStreaming.Infrastructure.Repositories;
using MovieStreaming.Infrastructure.UOW;
using Polly;
using Polly.Retry;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Setup mapster
TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);
builder.Services.Configure<RabbitMQConfiguration>(
	builder.Configuration.GetSection(RabbitMQConfiguration.Position));
builder.Services.AddHostedService<MovieDeletedConsumer>();

builder.Services.AddFluentValidation(options =>
{
	options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddResiliencePipeline(Consts.Retrypipeline, builder =>
{
	builder
		.AddRetry(new RetryStrategyOptions())
		.AddTimeout(TimeSpan.FromSeconds(60));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IFileCreationHelper, FileCreationHelper>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IMovieStreamRepository, MovieStreamRepository>();
//Register Database
builder.Services.AddDbContext<MovieStreamingDatabaseContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
	//Create Migration
	var databaseContext = scope.ServiceProvider.GetService<MovieStreamingDatabaseContext>();
	//SetupDatabase
	await new DatabaseCheckupService(databaseContext).SetupDatabase();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();

app.Run();
