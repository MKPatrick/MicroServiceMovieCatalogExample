using FluentValidation;
using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Application.Validation
{
	public class ReleaseDateValidation : AbstractValidator<DateRelease>
	{
		public ReleaseDateValidation()
		{
			RuleFor(x => x.Day).GreaterThan(0).WithMessage("Your Day has to be bigger than 0").LessThan(32).WithMessage("Your day has to be less than 32");
			RuleFor(x => x.Month).GreaterThan(0).WithMessage("Your Month has to be bigger than 0").LessThan(13).WithMessage("Your day has to be less than 13");
			RuleFor(x => x.Year).GreaterThan(0).WithMessage("Your Year has to be bigger than 0");
		}
	}
}