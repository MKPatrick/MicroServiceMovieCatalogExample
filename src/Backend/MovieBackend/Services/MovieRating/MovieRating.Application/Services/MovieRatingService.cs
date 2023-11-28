using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieRating.Application.DTO.MovieRating;
using MovieRating.Domain.Contracts;

namespace MovieRating.Application.Services
{
	public class MovieRatingService : IMovieRatingService
	{
		private readonly IMovieRatingRepository movieRatingRepository;
		private readonly IUnitOfWork unitOfWork;

		public MovieRatingService(IMovieRatingRepository movieRatingRepository, IUnitOfWork unitOfWork)
		{
			this.movieRatingRepository = movieRatingRepository;
			this.unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<GetMovieRatingDTO>> GetRatingFromMovie(int ID)
		{
			var result = await movieRatingRepository.GetRatesFromMovie(ID).ToListAsync();
			return result.Adapt<IEnumerable<GetMovieRatingDTO>>();
		}

		public async Task DeleteRatingsFromMovie(int MovieID)
		{
			await movieRatingRepository.DeleteRates(MovieID);
			await unitOfWork.SaveChangesAsync();
		}

		public async Task<IEnumerable<GetMovieAverageRatingDTO>> GetAllRatingsAverage()
		{
			var ratings = await movieRatingRepository
				.GetAllRates()
				.GroupBy(x => x.MovieID)
				.Select(x => new GetMovieAverageRatingDTO(
					x.Key,
					x.Average(y => (int)y.MovieRatedStar)))
				.ToArrayAsync();

			return ratings;
		}

		public async Task<GetMovieAverageRatingDTO> GetAverageRating(int MovieID)
		{
			var result = await (movieRatingRepository.GetRatesFromMovie(MovieID).AverageAsync(x => (int)x.MovieRatedStar));
			return new GetMovieAverageRatingDTO(MovieID, result);
		}
	}
}