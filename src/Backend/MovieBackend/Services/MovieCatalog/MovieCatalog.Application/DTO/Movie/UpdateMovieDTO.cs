﻿using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Application.DTO.Movie
{
	public record UpdateMovieDTO(int ID, string Title, string Description, DateRelease ReleaseDate);
}
