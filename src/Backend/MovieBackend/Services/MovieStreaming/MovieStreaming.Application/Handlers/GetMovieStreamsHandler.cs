using Mapster;
using MediatR;
using MovieStreaming.Application.DTOS;
using MovieStreaming.Application.Querries;
using MovieStreaming.Domain.Contracts;

namespace MovieStreaming.Application.Handlers
{
	public class GetMovieStreamsHandler : IRequestHandler<GetMovieStreamsQuerry, IEnumerable<GetMovieStreamDTO>>
	{
		private readonly IMovieStreamRepository movieStreamRepository;

		public GetMovieStreamsHandler(IMovieStreamRepository movieStreamRepository)
		{
			this.movieStreamRepository = movieStreamRepository;
		}

		public async Task<IEnumerable<GetMovieStreamDTO>> Handle(GetMovieStreamsQuerry request, CancellationToken cancellationToken)
		{
			var result = await movieStreamRepository.GetAllAsync();
			return result.Adapt<IEnumerable<GetMovieStreamDTO>>();
		}
	}
}