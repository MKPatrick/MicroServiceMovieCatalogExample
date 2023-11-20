using MediatR;
using MovieStreaming.Application.DTOS;

namespace MovieStreaming.Application.Querries
{
	public class GetMovieStreambyMovieIdQuerry : IRequest<GetMovieStreamDTO>
	{
		public int ID { get; }
		public GetMovieStreambyMovieIdQuerry(int ID)
		{
			this.ID = ID;
		}

	}
}
