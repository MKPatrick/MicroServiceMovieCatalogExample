using FluentValidation;
using MovieStreaming.Application.DTOS;

namespace MovieStreaming.Application.Validation
{
	public class UpdateStreamValidation : AbstractValidator<UpdateMovieStreamDTO>
	{
		public UpdateStreamValidation()
		{
			RuleFor(stream => stream.FormMovieFile).Must(stream => stream.FileName.EndsWith(".mp4")).WithMessage("Your Stream has to be a valid mp4 file!");
		}
	}
}