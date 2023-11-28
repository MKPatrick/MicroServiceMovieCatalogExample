using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using MovieCatalog.Application.DTO.Movie;
using MovieCatalog.Application.Validation;
using MovieCatalog.Domain.Entities.Movie;
using System.Text;

namespace MovieCatalog.Test.Validation
{
	[TestClass]
	public class UpdateMovieValidationTest
	{
		private UpdateMovieValidation updateMovieValidation;
		private Random rndm;

		public UpdateMovieValidationTest()
		{
			updateMovieValidation = new UpdateMovieValidation();
			rndm = new Random();
		}

		[TestMethod]
		public void Should_Have_Error_When_Title_Is_Empty()
		{
			var model = new UpdateMovieDTO(1, null, string.Empty, "TestDescription", new DateRelease() { Day = 12, Month = 12, Year = 12 });
			var result = updateMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(updateMovie => updateMovie.Title);
		}

		[TestMethod]
		public void Should_Have_Error_When_Title_Is_ToBig()
		{
			var model = new UpdateMovieDTO(1, null, CreateString(101), "TestDescription", new DateRelease() { Day = 12, Month = 12, Year = 12 });
			var result = updateMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(updateMovie => updateMovie.Title);
		}

		[TestMethod]
		public void Should_Have_Error_When_FileFormat_is_Incorrect()
		{
			var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
			IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt");
			var model = new UpdateMovieDTO(1, file, "TestTitle", CreateString(1001), new DateRelease() { Day = 12, Month = 12, Year = 12 });
			var result = updateMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(updateMovie => updateMovie.MovieImage);
		}

		[TestMethod]
		public void Should_Have_NO_Error_When_FileFormat_is_Correct()
		{
			var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
			IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.jpg");
			var model = new UpdateMovieDTO(1, file, "TestTitle", CreateString(1001), new DateRelease() { Day = 12, Month = 12, Year = 12 });
			var result = updateMovieValidation.TestValidate(model);
			result.ShouldNotHaveValidationErrorFor(updateMovie => updateMovie.MovieImage);
		}

		[TestMethod]
		public void Should_Have_Error_When_Description_Is_ToBig()
		{
			var model = new UpdateMovieDTO(1, null, "TestTitle", CreateString(1001), new DateRelease() { Day = 12, Month = 12, Year = 12 });
			var result = updateMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(updateMovie => updateMovie.Description);
		}

		[TestMethod]
		public void Should_Have_Error_When_Description_Is_Empty()
		{
			var model = new UpdateMovieDTO(1, null, "TestTitle", string.Empty, new DateRelease() { Day = 12, Month = 12, Year = 12 });
			var result = updateMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(updateMovie => updateMovie.Description);
		}

		[TestMethod]
		public void Should_Have_NO_Error()
		{
			var model = new UpdateMovieDTO(1, null, "TestTitle", "TestDescription", new DateRelease() { Day = 12, Month = 12, Year = 12 });
			var result = updateMovieValidation.TestValidate(model);
			result.ShouldNotHaveValidationErrorFor(updateMovie => updateMovie.Description);
			result.ShouldNotHaveValidationErrorFor(updateMovie => updateMovie.Title);
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