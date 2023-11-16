namespace MovieRating.Application.DTO.Rating
{
	public record AddRatingDTO( int MovieID,byte MovieRatedStar, string Comment, DateTime RatedTime);

}
