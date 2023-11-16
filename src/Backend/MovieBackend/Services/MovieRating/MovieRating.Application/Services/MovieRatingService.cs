using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieRating.Application.DTO.MovieRating;
using MovieRating.Domain.Contracts;

namespace MovieRating.Application.Services
{
	public class MovieRatingService : IMovieRatingService
	{
		private readonly IMovieRatingRepository movieRatingRepository;

		public MovieRatingService(IMovieRatingRepository movieRatingRepository)
		{
			this.movieRatingRepository = movieRatingRepository;
		}

		public async Task<IEnumerable<GetMovieRatingDTO>> GetRatingFromMovie(int ID)
		{
			var result = await movieRatingRepository.GetRatesFromMovie(ID).ToListAsync();
			return result.Adapt<IEnumerable<GetMovieRatingDTO>>();
		}

		public async Task<IEnumerable<GetMovieAverageRatingDTO>> GetAllRatings()
		{
			var result = await movieRatingRepository.GetAllRates().ToListAsync();
			return result.Adapt<IEnumerable<GetMovieAverageRatingDTO>>();
		}

		public async Task<GetMovieAverageRatingDTO> GetAverageRating(int MovieID)
		{
			var result = await (movieRatingRepository.GetRatesFromMovie(MovieID).AverageAsync(x => (int)x.MovieRatedStar));
			return new GetMovieAverageRatingDTO(MovieID, result);
		}

	}
}
