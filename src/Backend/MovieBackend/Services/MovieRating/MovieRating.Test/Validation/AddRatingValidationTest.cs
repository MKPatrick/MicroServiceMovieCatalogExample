using FluentValidation.TestHelper;
using MovieRating.Application.DTO.Rating;
using MovieRating.Application.Validation;

namespace MovieRating.Test.Validation
{
	[TestClass]
	public class AddRatingValidationTest
	{
		private AddRatingValidation addRatingValidation;
		private Random rndm;

		public AddRatingValidationTest()
		{
			addRatingValidation = new();
			rndm = new();
		}

		[TestMethod]
		public void Should_Have_Error_When_Rating_is_Below_1()
		{
			var model = new AddRatingDTO(1, 0, "TestComment");
			var result = addRatingValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(addRating => addRating.MovieRatedStar);
		}

		[TestMethod]
		public void Should_Have_Error_When_Rating_is_Above_5()
		{
			var model = new AddRatingDTO(1, 6, "TestComment");
			var result = addRatingValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(addRating => addRating.MovieRatedStar);
		}

		[TestMethod]
		public void Should_Have_Error_When_Comment_is_To_Big()
		{
			var model = new AddRatingDTO(1, 5, CreateString(1001));
			var result = addRatingValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(addRating => addRating.Comment);
		}

		private string CreateString(int stringLength)
		{
			const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
			char[] chars = new char[stringLength];

			for (int i = 0; i < stringLength; i++)
			{
				chars[i] = allowedChars[rndm.Next(0, allowedChars.Length)];
			}

			return new string(chars);
		}
	}
}