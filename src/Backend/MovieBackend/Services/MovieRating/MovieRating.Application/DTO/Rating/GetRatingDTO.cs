namespace MovieRating.Application.DTO.Rating
{
	public record GetRatingDTO(int ID, byte rating, string comment, DateTime RatedTime);
}
