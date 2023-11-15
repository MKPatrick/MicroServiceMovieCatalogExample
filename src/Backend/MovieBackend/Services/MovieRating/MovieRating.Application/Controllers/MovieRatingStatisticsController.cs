using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRating.Application.Controllers
{
	[Route("api/v1/ratingStatistics")]
	[ApiController]
	public class MovieRatingStatisticsController : ControllerBase
	{
		// GET: api/<MovieRatingStatisticsController>
		[HttpGet("average/{movieID}")]
		public IEnumerable<string> GetAverage(int movieID)
		{
			return new string[] { "value1", "value2" };
		}

		[HttpGet("average/{movieID}")]
		public IEnumerable<string> NewestRatings(int movieID, [FromQuery]int maxAmount)
		{
			return new string[] { "value1", "value2" };
		}

	}
}
