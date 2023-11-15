using MovieCatalog.Application.DTO.Rating;

namespace MovieCatalog.Application.Services
{
	public class ReviewService : IReviewService
	{
		private readonly HttpClient movieRatingHttpClient;
		public ReviewService(HttpClient movieratingHttpClient)
		{
			this.movieRatingHttpClient = movieratingHttpClient;
		}

		public async Task<ICollection<RatingAverageDTO>> GetAverageRatingOfAllMovies()
		{
			var result = await movieRatingHttpClient.GetFromJsonAsync<ICollection<RatingAverageDTO>>(string.Empty);
			return result;
		}

		public async Task<RatingAverageDTO> GetAverageratingOfMovie(int ID)
		{
			var result = await movieRatingHttpClient.GetFromJsonAsync<RatingAverageDTO>($"/{ID}");
			return result;
		}
	}
}
