namespace MovieCatalog.Domain.Entities.Movie
{
	public class Movie
	{
		public int ID { get; set; }
		public string? Title { get; set; }
		public string MovieImage { get; set; }
		public string? Description { get; set; }
		public DateRelease? ReleaseDate { get; set; }

	}
}
