namespace MovieCatalog.Application.Messaging
{
	public interface IMovieDeleteProduce
	{
		void SendMovieDeleteProduce(int MovieID);
	}
}