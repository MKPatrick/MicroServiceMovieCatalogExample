﻿using FluentValidation;
using MovieCatalog.Application.DTO.Movie;
using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Application.Validation
{
	public class AddMovieValidation : AbstractValidator<AddMovieDTO>
	{
		public AddMovieValidation()
		{
		RuleFor(movie => movie.Title).NotEmpty().WithMessage("Title cannot be empty").Length(1, 100).WithMessage("The Title must be between 1 and 100 characters");
			RuleFor(movie => movie.Description).NotEmpty().WithMessage("Description cannot be empty").Length(1, 1000).WithMessage("The Description must be between 1 and 1000 characters");
			RuleFor(movie => movie.ReleaseDate).SetValidator(new ReleaseDateValidation());
		}
	}

	
}