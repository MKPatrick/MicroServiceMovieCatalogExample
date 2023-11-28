using FluentValidation.TestHelper;
using MovieCatalog.Application.Validation;
using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Test.Validation
{
	[TestClass]
	public class ReleaseDataValidationTest
	{
		private ReleaseDateValidation releaseDataValidation;

		public ReleaseDataValidationTest()
		{
			releaseDataValidation = new ReleaseDateValidation();
		}

		[TestMethod]
		public void Should_Have_Error_When_Month_is_Lower_than_1()
		{
			var model = new DateRelease() { Month = 0, Day = 10, Year = 2023 };
			var result = releaseDataValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(releaseDate => releaseDate.Month);
		}

		[TestMethod]
		public void Should_Have_Error_When_Month_is_Bigger_than_12()
		{
			var model = new DateRelease() { Month = 13, Day = 10, Year = 2023 };
			var result = releaseDataValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(releaseDate => releaseDate.Month);
		}

		[TestMethod]
		public void Should_Have_Error_When_Year_is_Lower_than_0()
		{
			var model = new DateRelease() { Month = 10, Day = 10, Year = -1 };
			var result = releaseDataValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(releaseDate => releaseDate.Year);
		}

		[TestMethod]
		public void Should_Have_Error_When_Day_is_bigger_than_31()
		{
			var model = new DateRelease() { Month = 10, Day = 32, Year = 2023 };
			var result = releaseDataValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(releaseDate => releaseDate.Day);
		}

		[TestMethod]
		public void Should_Have_Error_When_Day_is_lower_than_1()
		{
			var model = new DateRelease() { Month = 10, Day = 0, Year = 2023 };
			var result = releaseDataValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(releaseDate => releaseDate.Day);
		}

		[TestMethod]
		public void Should_Have_NO_Error()
		{
			var model = new DateRelease() { Month = 12, Day = 5, Year = 2023 };
			var result = releaseDataValidation.TestValidate(model);
			result.ShouldNotHaveValidationErrorFor(releaseDate => releaseDate.Day);
			result.ShouldNotHaveValidationErrorFor(releaseDate => releaseDate.Month);
			result.ShouldNotHaveValidationErrorFor(releaseDate => releaseDate.Year);
		}
	}
}