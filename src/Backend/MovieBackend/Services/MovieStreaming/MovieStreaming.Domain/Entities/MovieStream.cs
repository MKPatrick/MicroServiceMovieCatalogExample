namespace MovieStreaming.Domain.Entities
{
	public class MovieStream
	{
		public int ID { get; set; }
		public int MovieID { get; set; }
		public string? MovieFile { get; set; }
	}
}