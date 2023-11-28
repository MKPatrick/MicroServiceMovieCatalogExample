using MovieCatalog.Application.DTO.Rating;
using System.Text.Json;

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
			var result = (await movieRatingHttpClient.GetFromJsonAsync<ICollection<RatingAverageDTO>>(""))
				?? Array.Empty<RatingAverageDTO>();
			return result;
		}

		public async Task<RatingAverageDTO> GetAverageratingOfMovie(int ID)
		{
			var result = await movieRatingHttpClient.GetAsync($"AverageMovieRating/{ID}");
			if (result.IsSuccessStatusCode)
			{
				return JsonSerializer.Deserialize<RatingAverageDTO>(await result.Content.ReadAsStringAsync());
			}
			else
			{
				// no ratings available
				return null;
			}
		}
	}
}