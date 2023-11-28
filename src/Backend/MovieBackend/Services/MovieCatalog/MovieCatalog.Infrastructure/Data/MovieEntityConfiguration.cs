using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Infrastructure.Data
{
	public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.Property(x => x.Title).IsRequired();
			builder.HasKey(x => x.ID);
			builder.Property(x => x.MovieImage).IsRequired(false);
			builder.OwnsOne(x => x.ReleaseDate);
		}
	}
}