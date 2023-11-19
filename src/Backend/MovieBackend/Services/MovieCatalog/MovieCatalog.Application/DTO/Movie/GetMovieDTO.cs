using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Application.DTO.Movie
{
	public record GetMovieDTO(int ID, string MovieImage,string Title, string Description, DateRelease ReleaseDate, double averageRating);
}

