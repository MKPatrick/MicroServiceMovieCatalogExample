using MovieRating.Application.DTO.Rating;

namespace MovieRating.Application.Services
{
	public interface IRatingService
	{
		Task<GetRatingDTO> AddRating(AddRatingDTO addRatingDTO);

		Task DeleteRating(int id);

		Task<GetRatingDTO> GetRating(int ID);

		Task<IEnumerable<GetRatingDTO>> GetRatings();

		Task UpdateRating(UpdateRatingDTO addRatingDTO);
	}
}