using Mapster;
using MediatR;
using MovieStreaming.Application.Commands;
using MovieStreaming.Application.DTOS;
using MovieStreaming.Application.Querries;
using MovieStreaming.Domain.Contracts;
using MovieStreaming.Domain.Entities;

namespace MovieStreaming.Application.Handlers
{
	public class DeleteMovieStreamHandler : IRequestHandler<UpdateMovieStreamCommand>
	{
		private readonly IMovieStreamRepository movieStreamRepository;
		private readonly IUnitOfWork unitOfWork;

		public DeleteMovieStreamHandler(IMovieStreamRepository movieStreamRepository, IUnitOfWork unitOfWork)
        {
			this.movieStreamRepository = movieStreamRepository;
			this.unitOfWork = unitOfWork;
		}
        public async Task Handle(UpdateMovieStreamCommand request, CancellationToken cancellationToken)
		{
			await movieStreamRepository.DeleteAsync(request.ID);
			await unitOfWork.SaveChangesAsync();
		}
	}
}
