using Mapster;
using MediatR;
using MovieStreaming.Application.Commands;
using MovieStreaming.Domain.Contracts;
using MovieStreaming.Domain.Entities;

namespace MovieStreaming.Application.Handlers
{
	public class UpdateMovieStreamHandler : IRequestHandler<UpdateMovieStreamCommand>
	{
		private readonly IMovieStreamRepository movieStreamRepository;
		private readonly IUnitOfWork unitOfWork;

		public UpdateMovieStreamHandler(IMovieStreamRepository movieStreamRepository, IUnitOfWork unitOfWork)
		{
			this.movieStreamRepository = movieStreamRepository;
			this.unitOfWork = unitOfWork;
		}
		public async Task Handle(UpdateMovieStreamCommand request, CancellationToken cancellationToken)
		{
			await movieStreamRepository.UpdateAsync(request.Adapt<MovieStream>());
			await unitOfWork.SaveChangesAsync();
		}
	}
}
