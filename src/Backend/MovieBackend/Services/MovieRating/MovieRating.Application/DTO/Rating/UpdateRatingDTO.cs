namespace MovieRating.Application.DTO.Rating
{
	public record UpdateRatingDTO(int ID, int MovieID, byte MovieRatedStar, string Comment, DateTime RatedTime);
}
