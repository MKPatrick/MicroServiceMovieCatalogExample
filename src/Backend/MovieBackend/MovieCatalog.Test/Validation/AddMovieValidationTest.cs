using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using MovieCatalog.Application.DTO.Movie;
using MovieCatalog.Application.Validation;
using MovieCatalog.Domain.Entities.Movie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Test.Validation
{
	[TestClass]
	public class AddMovieValidationTest
	{

        private AddMovieValidation addMovieValidation;
		private Random rndm;
        public AddMovieValidationTest()
        {
			addMovieValidation= new AddMovieValidation();
			rndm = new Random();
		}


        [TestMethod]
        public void Should_Have_Error_When_Description_is_Empty()
        {
			var model = new AddMovieDTO("TestTitle", string.Empty, new DateRelease() { Month=1, Day=1,Year=1}, null);
			var result = addMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(addMovie => addMovie.Description);
		}


		[TestMethod]
		public void Should_Have_Error_When_Description_is_ToBig()
		{
			var model = new AddMovieDTO("TestTitle", CreateString(1001), new DateRelease() { Month = 1, Day = 1, Year = 1 }, null);
			var result = addMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(addMovie => addMovie.Description);
		}

		[TestMethod]
		public void Should_Have_Error_When_Title_is_Empty()
		{
			var model = new AddMovieDTO(string.Empty, "TestDescription", new DateRelease() { Month = 1, Day = 1, Year = 1 }, null);
			var result = addMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(addMovie => addMovie.Title);
		}


		[TestMethod]
		public void Should_Have_Error_When_Title_is_ToBig()
		{
			var model = new AddMovieDTO(CreateString(101), "TestDescription", new DateRelease() { Month = 1, Day = 1, Year = 1 }, null);
			var result = addMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(addMovie => addMovie.Title);
		}


		[TestMethod]
		public void Should_Have_NO_Error()
		{
			var model = new AddMovieDTO("TestTitle", "TestDescription", new DateRelease() { Month = 1, Day = 1, Year = 1 }, null);
			var result = addMovieValidation.TestValidate(model);
			result.ShouldNotHaveValidationErrorFor(addMovie => addMovie.ReleaseDate);
			result.ShouldNotHaveValidationErrorFor(addMovie => addMovie.Title);
			result.ShouldNotHaveValidationErrorFor(addMovie => addMovie.Description);

		}


		[TestMethod]
		public void Should_Have_Error_When_FileFormat_is_Incorrect()
		{
			var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
			IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt");
			var model = new AddMovieDTO("TestTitle", "TestDescription", new DateRelease() { Month = 1, Day = 1, Year = 1 }, file);
			var result = addMovieValidation.TestValidate(model);
			result.ShouldHaveValidationErrorFor(addMovie => addMovie.MovieImage);
		}

		[TestMethod]
		public void Should_Have_NO_Error_When_FileFormat_is_Correct()
		{
			var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
			IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.jpg");
			var model = new AddMovieDTO("TestTitle", "TestDescription", new DateRelease() { Month = 1, Day = 1, Year = 1 }, file);
			var result = addMovieValidation.TestValidate(model);
			result.ShouldNotHaveValidationErrorFor(addMovie => addMovie.MovieImage);
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
