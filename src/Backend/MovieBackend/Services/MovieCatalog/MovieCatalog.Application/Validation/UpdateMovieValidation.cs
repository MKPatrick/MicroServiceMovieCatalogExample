using FluentValidation;
using MovieCatalog.Application.DTO.Movie;

namespace MovieCatalog.Application.Validation
{
	public class UpdateMovieValidation : AbstractValidator<UpdateMovieDTO>
	{
		public UpdateMovieValidation()
		{
			RuleFor(movie => movie.Title).NotEmpty().WithMessage("Title cannot be empty").Length(1, 100).WithMessage("The Title must be between 1 and 100 characters");
			RuleFor(movie => movie.Description).NotEmpty().WithMessage("Description cannot be empty").Length(1, 1000).WithMessage("The Description must be between 1 and 1000 characters");
			RuleFor(movie => movie.ReleaseDate).SetValidator(new ReleaseDateValidation());
			RuleFor(movie => movie.MovieImage).Must(movie => movie.FileName.EndsWith(".jpg") || movie.FileName.EndsWith(".jpeg") || movie.FileName.EndsWith(".png")).WithMessage("Your file have to be a valid jpeg or png.").When(x => x.MovieImage != null);
		}
	}
}