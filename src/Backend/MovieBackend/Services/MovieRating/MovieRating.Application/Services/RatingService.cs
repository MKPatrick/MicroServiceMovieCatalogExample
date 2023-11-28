using Mapster;
using MovieRating.Application.DTO.Rating;
using MovieRating.Domain.Contracts;
using MovieRating.Domain.Entities;

namespace MovieRating.Application.Services
{
	public class RatingService : IRatingService
	{
		private readonly IRatingRepository ratingRepository;
		private readonly IUnitOfWork unitOfWork;

		public RatingService(IRatingRepository movieRatingRepository, IUnitOfWork unitOfWork)
		{
			this.ratingRepository = movieRatingRepository;
			this.unitOfWork = unitOfWork;
		}

		public async Task<GetRatingDTO> GetRating(int ID)
		{
			var result = await ratingRepository.GetByIdAsync(ID);
			return result.Adapt<GetRatingDTO>();
		}

		public async Task<IEnumerable<GetRatingDTO>> GetRatings()
		{
			var result = await ratingRepository.GetAllAsync();
			return result.Adapt<IEnumerable<GetRatingDTO>>();
		}

		public async Task<GetRatingDTO> AddRating(AddRatingDTO addRatingDTO)
		{
			var result = await ratingRepository.AddAsync(addRatingDTO.Adapt<MovieRate>());
			await unitOfWork.SaveChangesAsync();
			return result.Adapt<GetRatingDTO>();
		}

		public async Task UpdateRating(UpdateRatingDTO addRatingDTO)
		{
			await ratingRepository.UpdateAsync(addRatingDTO.Adapt<MovieRate>());
			await unitOfWork.SaveChangesAsync();
		}

		public async Task DeleteRating(int id)
		{
			await ratingRepository.DeleteAsync(id);
			await unitOfWork.SaveChangesAsync();
		}
	}
}