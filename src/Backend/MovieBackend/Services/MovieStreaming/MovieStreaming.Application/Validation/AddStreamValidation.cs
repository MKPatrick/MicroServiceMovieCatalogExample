using FluentValidation;
using MovieStreaming.Application.DTOS;

namespace MovieStreaming.Application.Validation
{
	public class AddStreamValidation : AbstractValidator<AddMovieStreamDTO>
	{
		public AddStreamValidation()
		{
			RuleFor(stream => stream.FormMovieFile).NotNull().WithMessage("You have to upload a .mp4 file!").Must(stream => stream.FileName.EndsWith(".mp4")).WithMessage("Your Stream has to be a valid mp4 file!").When(stream=> stream.FormMovieFile!=null);
		}
	}
}
