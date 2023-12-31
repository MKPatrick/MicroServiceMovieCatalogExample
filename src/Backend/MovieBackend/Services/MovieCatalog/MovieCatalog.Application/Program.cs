using FluentValidation.AspNetCore;
using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.Application.Configuration;
using MovieCatalog.Application.Messaging;
using MovieCatalog.Application.Services;
using MovieCatalog.Domain.Contracts;
using MovieCatalog.Infrastructure.Data;
using MovieCatalog.Infrastructure.Repositories;
using MovieCatalog.Infrastructure.UOW;
using Polly;
using Polly.Extensions.Http;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Setup mapster
TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

builder.Services.AddFluentValidation(options =>
{
	options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Database
builder.Services.AddDbContext<MovieDatabaseContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<RabbitMQConfiguration>(
	builder.Configuration.GetSection(RabbitMQConfiguration.Position));

//register Rabbitmq
builder.Services.AddScoped<IMovieDeleteProduce, MovieDeleteProduce>();

//Register Services
builder.Services.AddTransient<IMovieService, MovieService>();

var retryPolicy = HttpPolicyExtensions
  .HandleTransientHttpError()
  .RetryAsync(3);

var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);

builder.Services.AddHttpClient<IReviewService, ReviewService>(client =>
{
	client.BaseAddress = new Uri(builder.Configuration.GetSection("APIS")["ReviewAPI"]);
}).AddPolicyHandler(retryPolicy).AddPolicyHandler(timeoutPolicy);

//Register Repository
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	//Create Migration
	var databaseContext = scope.ServiceProvider.GetService<MovieDatabaseContext>();
	//SetupDatabase
	await new DatabaseCheckupService(databaseContext).SetupDatabase();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseStaticFiles();

app.MapControllers();

app.Run();