using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Application.DTO.Movie;
using MovieCatalog.Application.Services;

namespace MovieCatalog.Application.Controllers
{
	[Route("api/v1/movies")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IMovieService movieService;
		private readonly IReviewService reviewService;

		public MovieController(IMovieService movieService, IReviewService reviewService)
		{
			this.movieService = movieService;
			this.reviewService = reviewService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetMovieDTO>>> Get()
		{
			var result = await movieService.GetAllMovies();
			var reviews = await reviewService.GetAverageRatingOfAllMovies();

			var res = result
				.Select(x =>
				new GetMovieDTO(
					x.ID,
						x.MovieImage,
					x.Title,
					x.Description,
					x.ReleaseDate,
					reviews.FirstOrDefault(y => y.MovieID == x.ID)?.RatingAverage ?? 0)
				);

			return Ok(res);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetMovieDTO>> Get(int id)
		{
			var movieResult = await movieService.GetMovie(id);
			if (movieResult == null)
				return NotFound(new ProblemDetails() { Detail = "Movie was not found. Please check your ID" });
			var reviewResult = await reviewService.GetAverageratingOfMovie(id);
			if (reviewResult == null) return movieResult;
			var aggregatedResult = new GetMovieDTO(movieResult.ID, movieResult.MovieImage, movieResult.Title, movieResult.Description, movieResult.ReleaseDate, reviewResult.RatingAverage);
			return Ok(aggregatedResult);
		}

		[HttpPost]
		public async Task<ActionResult<GetMovieDTO>> Post([FromForm] AddMovieDTO value)
		{
			var createdMovie = await movieService.AddMovie(value);
			return Created(string.Empty, createdMovie);
		}

		[HttpPut()]
		public async Task<ActionResult> Put([FromForm] UpdateMovieDTO value)
		{
			await movieService.UpdateMovie(value);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await movieService.DeleteMovie(id);
			return Ok();
		}
	}
}