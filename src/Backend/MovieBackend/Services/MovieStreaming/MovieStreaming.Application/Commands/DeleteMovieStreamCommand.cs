using MediatR;

namespace MovieStreaming.Application.Commands
{
	public class DeleteMovieStreamCommand : IRequest
	{
		public int ID { get; private set; }

		public DeleteMovieStreamCommand(int iD)
		{
			ID = iD;
		}
	}
}