using FluentValidation.AspNetCore;
using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieRating.Application.Services;
using MovieRating.Domain.Contracts;
using MovieRating.Infrastructure.Data;
using MovieRating.Infrastructure.Repository;
using MovieRating.Infrastructure.UOW;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Setup mapster
TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

builder.Services.AddFluentValidation(options =>
{
	options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register service
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IMovieRatingService, MovieRatingService>();

//Repository
builder.Services.AddTransient<IRatingRepository, RatingRepository>();
builder.Services.AddTransient<IMovieRatingRepository, MovieRateRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<MovieRatingDatabaseContext>(options =>
{
	options.UseMySql(
				builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("5.7.37-mysql"),
				builder =>
				{
					builder.EnableRetryOnFailure(5);
				});
	options.EnableDetailedErrors();
	//options.UseSqlite("Data Source=TEST.db");
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
	//Create Migration
	var databaseContext = scope.ServiceProvider.GetService<MovieRatingDatabaseContext>();
	//SetupDatabase
	await new DatabaseCheckupService(databaseContext).SetupDatabase();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.Run();
