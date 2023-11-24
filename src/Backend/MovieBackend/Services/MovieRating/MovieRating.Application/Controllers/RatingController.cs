using Microsoft.AspNetCore.Mvc;
using MovieRating.Application.DTO.Rating;
using MovieRating.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRating.Application.Controllers
{
	[Route("api/v1/Ratings")]
	[ApiController]
	public class RatingController : ControllerBase
	{
		private readonly IRatingService ratingService;

		public RatingController(IRatingService ratingService)
		{
			this.ratingService = ratingService;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetRatingDTO>>> Get()
		{
			return Ok(await ratingService.GetRatings());
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<GetRatingDTO>> Get(int id)
		{
			var result = await ratingService.GetRating(id);
			if (result == null)
				return NotFound(new ProblemDetails() { Detail = "Review was not found. Please check your ID" });
			return Ok(result);
		}


		[HttpPost]
		public async Task<ActionResult> Post([FromBody] AddRatingDTO value)
		{
			var createdRaiting = await ratingService.AddRating(value);
			return Created("", createdRaiting);
		}


		[HttpPut()]
		public async Task<ActionResult> Put([FromBody] UpdateRatingDTO value)
		{
			await ratingService.UpdateRating(value);
			return Ok();
		}


		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await ratingService.DeleteRating(id);
			return Ok();
		}
	}
}
