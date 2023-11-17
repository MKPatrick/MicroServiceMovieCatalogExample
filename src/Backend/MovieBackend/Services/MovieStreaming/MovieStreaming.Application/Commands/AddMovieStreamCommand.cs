using MediatR;
using MovieStreaming.Application.DTOS;

namespace MovieStreaming.Application.Commands
{
	public class AddMovieStreamCommand : IRequest<GetMovieStreamDTO>
	{
		public int MovieID { get; private set; }
		public string MovieFile { get; private set; }

		public AddMovieStreamCommand(int movieID, string movieFile)
		{
			this.MovieID = movieID;
			this.MovieFile = movieFile;
		}

	}
}
