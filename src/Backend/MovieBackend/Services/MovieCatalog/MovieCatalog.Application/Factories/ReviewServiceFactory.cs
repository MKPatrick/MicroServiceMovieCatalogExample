using MovieCatalog.Application.Services;

namespace MovieCatalog.Application.Factories
{
	public class ReviewServiceFactory
	{
		/// <summary>
		/// Creates an Review service
		/// </summary>
		/// <param name="baseURL">the base URL for the API requests e.g. http://reviews/api/v1/reviews</param>
		/// <returns></returns>
		public static IReviewService Create(string baseURL)
		{
			var httpClient = new HttpClient { BaseAddress = new Uri(baseURL) };
			return new ReviewService(httpClient);
		}
	}
}