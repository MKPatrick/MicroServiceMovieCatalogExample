using MediatR;

namespace MovieStreaming.Application.Commands
{
	public class UpdateMovieStreamCommand : IRequest
	{
		public  int ID { get; private set; }
		public int MovieID { get; private set; }
		public string MovieFile { get; private set; }

		public UpdateMovieStreamCommand(int ID, int movieID, string movieFile)
        {
			this.ID = ID;
			this.MovieID = movieID;
			this.MovieFile = movieFile;
		}
    }
}
