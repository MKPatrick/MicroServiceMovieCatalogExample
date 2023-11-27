using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieCatalog.Application.Controllers;
using MovieCatalog.Application.DTO.Movie;
using MovieCatalog.Application.DTO.Rating;
using MovieCatalog.Application.Services;
using System.Text;

namespace MovieCatalog.Test.Controllers
{
	[TestClass]
	public class MovieControllerTest
	{
		private Fixture fixture;

		public MovieControllerTest()
		{
			fixture = new Fixture();
		}


		[TestMethod]
		public async Task Should_Have_RESULTOK_Get_All_Movies()
		{
			fixture.Customize<GetMovieDTO>(customize =>
			customize.With(movie => movie.averageRating, 0));
			var expectedMovie1 = fixture.Create<GetMovieDTO>();
			var expectedMovie2 = fixture.Create<GetMovieDTO>();
			var movieService = new Mock<IMovieService>();
			var reviewService = new Mock<IReviewService>();

			movieService.Setup(service => service.GetAllMovies()).ReturnsAsync(new List<GetMovieDTO>() { expectedMovie1, expectedMovie2 });
			reviewService.Setup(x => x.GetAverageRatingOfAllMovies()).ReturnsAsync(new List<RatingAverageDTO>());
			MovieController controller = new MovieController(movieService.Object, reviewService.Object);
			var result = await controller.Get();
			var castedResult = result.Result as OkObjectResult;
			Assert.IsNotNull(castedResult);
			var movies = castedResult.Value as IEnumerable<GetMovieDTO>;
			Assert.IsNotNull(movies);
			Assert.AreEqual(expectedMovie1, movies.ToList()[0]);
			Assert.AreEqual(expectedMovie2, movies.ToList()[1]);
		}

		[TestMethod]
		public async Task Should_Have_RESULTOK_Get_MovieByID()
		{
			fixture.Customize<GetMovieDTO>(customize =>
			customize.With(movie => movie.averageRating, 2));
			var expectedMovie = fixture.Create<GetMovieDTO>();
			var movieService = new Mock<IMovieService>();
			var reviewService = new Mock<IReviewService>();

			movieService.Setup(service => service.GetMovie(1)).ReturnsAsync(expectedMovie);
			reviewService.Setup(x => x.GetAverageratingOfMovie(1)).ReturnsAsync(new RatingAverageDTO(1, 2));
			MovieController controller = new MovieController(movieService.Object, reviewService.Object);
			var result = await controller.Get(1);
			var castedResult = result.Result as OkObjectResult;
			Assert.IsNotNull(castedResult);
			var movie = castedResult.Value as GetMovieDTO;
			Assert.IsNotNull(movie);
			Assert.AreEqual(expectedMovie, movie);

		}

		[TestMethod]
		public async Task Should_Have_RESULTNOTFOUND_Get_MovieByID()
		{
			fixture.Customize<GetMovieDTO>(customize =>
			customize.With(movie => movie.averageRating, 2));
			var expectedMovie = fixture.Create<GetMovieDTO>();
			var movieService = new Mock<IMovieService>();
			var reviewService = new Mock<IReviewService>();
			MovieController controller = new MovieController(movieService.Object, reviewService.Object);
			var result = await controller.Get(1);
			var castedResult = result.Result as NotFoundObjectResult;
			Assert.IsNotNull(castedResult);
		}

		[TestMethod]
		public async Task Should_Have_RESULTCREATED_Add_Movie()
		{
			var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
			fixture.Customize<IFormFile>(x => x.FromFactory(() => new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt")));
			var expectedMovie = fixture.Create<GetMovieDTO>();
			var addMovie = fixture.Create<AddMovieDTO>();
			var movieService = new Mock<IMovieService>();
			movieService.Setup(x => x.AddMovie(addMovie)).ReturnsAsync(expectedMovie);
			var reviewService = new Mock<IReviewService>();
			MovieController controller = new MovieController(movieService.Object, reviewService.Object);
			var result = await controller.Post(addMovie);
			var castedResult = result.Result as CreatedResult;
			Assert.IsNotNull(castedResult);
		}


		[TestMethod]
		public async Task Should_Have_RESULTOK_Update_Movie()
		{
			var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
			fixture.Customize<IFormFile>(x => x.FromFactory(() => new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt")));
			var expectedMovie = fixture.Create<GetMovieDTO>();
			var updateMovie = fixture.Create<UpdateMovieDTO>();
			var movieService = new Mock<IMovieService>();
			movieService.Setup(x => x.UpdateMovie(updateMovie));
			var reviewService = new Mock<IReviewService>();
			MovieController controller = new MovieController(movieService.Object, reviewService.Object);
			var result = await controller.Put(updateMovie);
			var castedResult = result as OkResult;
			Assert.IsNotNull(castedResult);
		}


		[TestMethod]
		public async Task Should_Have_RESULTOK_Delete_Movie()
		{
			var expectedMovie = fixture.Create<GetMovieDTO>();
			var movieService = new Mock<IMovieService>();
			movieService.Setup(x => x.DeleteMovie(1));
			var reviewService = new Mock<IReviewService>();
			MovieController controller = new MovieController(movieService.Object, reviewService.Object);
			var result = await controller.Delete(1);
			var castedResult = result as OkResult;
			Assert.IsNotNull(castedResult);
		}


	}
}
