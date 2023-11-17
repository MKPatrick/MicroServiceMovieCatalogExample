namespace MovieRating.Application.DTO.Rating
{
	public record UpdateRatingDTO(int ID, int MovieID, int MovieRatedStar, string Comment);
}
