using Mapster;
using MediatR;
using MovieStreaming.Application.Commands;
using MovieStreaming.Application.DTOS;
using MovieStreaming.Domain.Contracts;
using MovieStreaming.Domain.Entities;

namespace MovieStreaming.Application.Handlers
{
	public class AddMovieStreamHandler : IRequestHandler<AddMovieStreamCommand, GetMovieStreamDTO>
	{
		private readonly IMovieStreamRepository movieStreamRepository;
		private readonly IUnitOfWork unitOfWork;

		public AddMovieStreamHandler(IMovieStreamRepository movieStreamRepository, IUnitOfWork unitOfWork)
		{
			this.movieStreamRepository = movieStreamRepository;
			this.unitOfWork = unitOfWork;
		}
		public async Task<GetMovieStreamDTO> Handle(AddMovieStreamCommand request, CancellationToken cancellationToken)
		{
			var result = await movieStreamRepository.AddAsync(request.Adapt<MovieStream>());
			await unitOfWork.SaveChangesAsync();
			return result.Adapt<GetMovieStreamDTO>();
		}
	}
}
