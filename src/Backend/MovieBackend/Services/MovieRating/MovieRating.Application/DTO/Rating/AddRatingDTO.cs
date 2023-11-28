namespace MovieRating.Application.DTO.Rating
{
	public record AddRatingDTO(int MovieID, int MovieRatedStar, string Comment);
}