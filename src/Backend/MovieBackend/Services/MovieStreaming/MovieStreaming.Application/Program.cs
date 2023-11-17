using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MovieStreaming.Domain.Contracts;
using MovieStreaming.Infrastructure.Data;
using MovieStreaming.Infrastructure.Repositories;
using MovieStreaming.Infrastructure.UOW;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Setup mapster
TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapControllers();

app.Run();
