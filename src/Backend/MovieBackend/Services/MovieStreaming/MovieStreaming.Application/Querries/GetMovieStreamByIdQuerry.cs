using MediatR;
using MovieStreaming.Application.DTOS;

namespace MovieStreaming.Application.Querries
{
	public class GetMovieStreamByIdQuerry : IRequest<GetMovieStreamDTO>
	{
		public int ID { get; }

		public GetMovieStreamByIdQuerry(int ID)
		{
			this.ID = ID;
		}
	}
}