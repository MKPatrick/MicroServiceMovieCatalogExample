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

		public MovieController(IMovieService movieService)
		{
			this.movieService = movieService;
		}

		// GET: api/<MovieController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetMovieDTO>>> Get()
		{
			var result = await movieService.GetAllMovie();
			return Ok(result);
		}

		// GET api/<MovieController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<GetMovieDTO>> Get(int id)
		{
			var result = await movieService.GetMovie(id);
			if (result == null)
				return NotFound(new ProblemDetails() { Detail = "Movie was not found. Please check your ID" });
			return Ok(result);
		}

		// POST api/<MovieController>
		[HttpPost]
		public async Task<ActionResult<GetMovieDTO>> Post([FromBody] AddMovieDTO value)
		{
			await movieService.AddMovie(value);
			return Created();
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
