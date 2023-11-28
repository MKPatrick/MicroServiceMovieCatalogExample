namespace MovieRating.Application.DTO.MovieRating
{
	public record GetMovieRatingDTO(int ID, int MovieID, int MovieRatedStar, string comment, DateTime RatedTime);
}