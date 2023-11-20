using MediatR;

namespace MovieStreaming.Application.Commands
{
	public class UpdateMovieStreamCommand : IRequest
	{
		public int ID { get; private set; }
		public IFormFile FormMovieFile { get; }

		public UpdateMovieStreamCommand(int ID, IFormFile FormMovieFile)
		{
			this.ID = ID;

			this.FormMovieFile = FormMovieFile;

		}
	}
}
