using MediatR;
using MovieStreaming.Application.DTOS;

namespace MovieStreaming.Application.Querries
{
	public class GetMovieStreamsQuerry : IRequest<IEnumerable<GetMovieStreamDTO>>
	{
		public GetMovieStreamsQuerry()
		{
		}
	}
}