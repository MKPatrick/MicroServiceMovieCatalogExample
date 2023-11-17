using FluentValidation;
using MovieRating.Application.DTO.Rating;

namespace MovieRating.Application.Validation
{
	public class AddRatingValidation : AbstractValidator<AddRatingDTO>
	{
        public AddRatingValidation()
        {
			RuleFor(x => x.MovieRatedStar).GreaterThan(0).WithMessage("Your Review has to be bigger than 0").LessThan(6).WithMessage("Your Review has to be less than 6");
			RuleFor(x => x.Comment).MinimumLength(0).WithMessage("Your Review Comment has to be bigger than.").MaximumLength(1000).WithMessage("Your Comment has to be less than 1000 characters");
		}
	}
}
