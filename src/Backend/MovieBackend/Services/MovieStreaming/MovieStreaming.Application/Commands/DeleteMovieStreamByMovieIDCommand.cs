using MediatR;

namespace MovieStreaming.Application.Commands
{
	public class DeleteMovieStreamByMovieIDCommand : IRequest
	{
		public int MovieID { get; private set; }

		public DeleteMovieStreamByMovieIDCommand(int MovieID)
		{
			this.MovieID = MovieID;
		}
	}
}
