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

		// GET: api/<MovieController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetMovieDTO>>> Get()
		{
			var result = await movieService.GetAllMovies();
			var reviews = await reviewService.GetAverageRatingOfAllMovies();

			var res = result
				.Select(x =>
				new GetMovieDTO(
					x.ID,
					x.Title,
					x.Description,
					x.ReleaseDate,
					reviews.FirstOrDefault(y => y.MovieID == x.ID)?.RatingAverage ?? 0)
				);

			return Ok(res);
		}

		// GET api/<MovieController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<GetMovieDTO>> Get(int id)
		{
			var result = await movieService.GetMovie(id);
			if (result == null)
				return NotFound(new ProblemDetails() { Detail = "Movie was not found. Please check your ID" });
			var reviewResult = await reviewService.GetAverageratingOfMovie(id);
			var aggregatedResult = new GetMovieDTO(result.ID, result.Description, result.Description, result.ReleaseDate, reviewResult.RatingAverage);
			return Ok(aggregatedResult);
		}

		// POST api/<MovieController>
		[HttpPost]
		public async Task<ActionResult<GetMovieDTO>> Post([FromBody] AddMovieDTO value)
		{
			var createdMovie=await movieService.AddMovie(value);
			return Created(string.Empty,createdMovie);
		}

		// PUT api/<MovieController>/5
		[HttpPut()]
		public async Task<ActionResult> Put([FromBody] UpdateMovieDTO value)
		{
			await movieService.UpdateMovie(value);
			return Ok();
		}

		// DELETE api/<MovieController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await movieService.DeleteMovie(id);
			return Ok();
		}
	}
}
