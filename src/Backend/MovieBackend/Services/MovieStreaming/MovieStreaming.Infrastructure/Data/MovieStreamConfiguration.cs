using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStreaming.Domain.Entities;

namespace MovieStreaming.Infrastructure.Data
{
	public class MovieStreamConfiguration : IEntityTypeConfiguration<MovieStream>
	{
		public void Configure(EntityTypeBuilder<MovieStream> builder)
		{
			builder.HasIndex(x => x.MovieID).IsUnique();
		}
	}
}