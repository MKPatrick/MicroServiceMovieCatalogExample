using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRating.Domain.Entities;

namespace MovieRating.Infrastructure.Data
{
	public class MovieRatingDatabaseConfiguration : IEntityTypeConfiguration<MovieRate>
	{
		public void Configure(EntityTypeBuilder<MovieRate> builder)
		{
			builder.HasKey(p => p.ID);
		}
	}
}