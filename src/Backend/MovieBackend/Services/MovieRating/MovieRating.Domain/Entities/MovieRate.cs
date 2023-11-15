namespace MovieRating.Domain.Entities
{
	public class MovieRate
	{
		public int ID { get; set; }
		public int MovieID { get; set; }
		public MovieStar MovieRatedStar { get; set; }
		public string Comment { get; set; }
	}
}
