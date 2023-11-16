namespace MovieRating.Application.DTO.MovieRating
{
	public record GetMovieRatingDTO(int ID, int MovieID,byte rating, string comment,DateTime RatedTime);

}
