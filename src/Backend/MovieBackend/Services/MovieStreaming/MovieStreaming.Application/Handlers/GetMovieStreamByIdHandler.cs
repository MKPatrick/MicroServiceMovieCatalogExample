using Mapster;
using MediatR;
using MovieStreaming.Application.DTOS;
using MovieStreaming.Application.Querries;
using MovieStreaming.Domain.Contracts;

namespace MovieStreaming.Application.Handlers
{
	public class GetMovieStreamByIdHandler : IRequestHandler<GetMovieStreamByIdQuerry, GetMovieStreamDTO>
	{
		private readonly IMovieStreamRepository movieStreamRepository;

		public GetMovieStreamByIdHandler(IMovieStreamRepository movieStreamRepository)
		{
			this.movieStreamRepository = movieStreamRepository;
		}

		public async Task<GetMovieStreamDTO> Handle(GetMovieStreamByIdQuerry request, CancellationToken cancellationToken)
		{
			var result = await movieStreamRepository.GetByIdAsync(request.ID);
			return result.Adapt<GetMovieStreamDTO>();
		}
	}
}