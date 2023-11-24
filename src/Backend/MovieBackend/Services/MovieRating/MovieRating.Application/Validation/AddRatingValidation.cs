using FluentValidation;
using MovieRating.Application.DTO.Rating;

namespace MovieRating.Application.Validation
{
	public class AddRatingValidation : AbstractValidator<AddRatingDTO>
	{
		public AddRatingValidation()
		{
			RuleFor(x => x.MovieRatedStar).GreaterThan(0).WithMessage("Your Review has to be bigger than 0 Stars").LessThan(6).WithMessage("Your Review has to be less than 6 Stars");
			RuleFor(x => x.Comment).MinimumLength(0).WithMessage("Your Review Comment is not allowed to be empty").MaximumLength(1000).WithMessage("Your Comment has to be less than 1000 characters");
			RuleFor(x => x.MovieID).NotNull().WithMessage("A Movie ID is required for a rating");
		}
	}
}
