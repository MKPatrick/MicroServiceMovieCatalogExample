using Microsoft.EntityFrameworkCore;
using MovieCatalog.Domain.Entities.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Infrastructure.Data
{
	public partial class MovieDatabaseContext : DbContext
	{
		private DbSet<Movie> Movies { get; set; }
		public MovieDatabaseContext(DbContextOptions options) : base(options)
		{
		
		}


	}
}
