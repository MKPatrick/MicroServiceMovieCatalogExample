using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.Application.Factories;
using MovieCatalog.Application.Services;
using MovieCatalog.Domain.Contracts;
using MovieCatalog.Infrastructure.Data;
using MovieCatalog.Infrastructure.Repositories;
using MovieCatalog.Infrastructure.UOW;

var builder = WebApplication.CreateBuilder(args);

//Setup mapster
TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Register Database
builder.Services.AddDbContext<MovieDatabaseContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//Register Services
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient(x => ReviewServiceFactory.Create(builder.Configuration.GetSection("APIS")["ReviewAPI"]));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
