using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Application.DTO.Movie
{
	public record AddMovieDTO(string Title, string Description, DateRelease ReleaseDate, IFormFile? MovieImage);
}