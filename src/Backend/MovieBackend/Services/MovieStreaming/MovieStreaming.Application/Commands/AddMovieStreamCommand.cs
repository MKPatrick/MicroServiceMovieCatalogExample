using MediatR;
using MovieStreaming.Application.DTOS;

namespace MovieStreaming.Application.Commands
{
	public class AddMovieStreamCommand : IRequest<GetMovieStreamDTO>
	{
		public IFormFile FormMovieFile { get; }

		public int MovieID { get; private set; }

		public AddMovieStreamCommand(int movieID, IFormFile FormMovieFile)
		{
			this.MovieID = movieID;
			this.FormMovieFile = FormMovieFile;
		}
	}
}