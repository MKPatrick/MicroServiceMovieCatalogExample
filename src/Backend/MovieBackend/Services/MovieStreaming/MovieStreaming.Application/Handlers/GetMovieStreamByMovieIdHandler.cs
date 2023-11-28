using Mapster;
using MediatR;
using MovieStreaming.Application.DTOS;
using MovieStreaming.Application.Querries;
using MovieStreaming.Domain.Contracts;

namespace MovieStreaming.Application.Handlers
{
	public class GetMovieStreamByMovieIdHandler : IRequestHandler<GetMovieStreambyMovieIdQuerry, GetMovieStreamDTO>
	{
		private readonly IMovieStreamRepository movieStreamRepository;

		public GetMovieStreamByMovieIdHandler(IMovieStreamRepository movieStreamRepository)
		{
			this.movieStreamRepository = movieStreamRepository;
		}

		public async Task<GetMovieStreamDTO?> Handle(GetMovieStreambyMovieIdQuerry request, CancellationToken cancellationToken)
		{
			var result = await movieStreamRepository.GetStreamForMovieID(request.ID);
			if (result != null)
			{
				return result.Adapt<GetMovieStreamDTO>();
			}
			return null;
		}
	}
}