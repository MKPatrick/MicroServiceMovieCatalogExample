namespace MovieRating.Application.DTO.Rating
{
	public record GetRatingDTO(int ID, byte MovieRatedStar, string comment, DateTime RatedTime);
}
