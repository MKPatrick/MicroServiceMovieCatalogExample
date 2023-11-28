using MediatR;
using MovieStreaming.Application.Commands;
using MovieStreaming.Domain.Contracts;

namespace MovieStreaming.Application.Handlers
{
	public class DeleteMovieStreamByMovieIDHandler : IRequestHandler<DeleteMovieStreamByMovieIDCommand>
	{
		private readonly IMovieStreamRepository movieStreamRepository;
		private readonly IUnitOfWork unitOfWork;

		public DeleteMovieStreamByMovieIDHandler(IMovieStreamRepository movieStreamRepository, IUnitOfWork unitOfWork)
		{
			this.movieStreamRepository = movieStreamRepository;
			this.unitOfWork = unitOfWork;
		}

		public async Task Handle(DeleteMovieStreamByMovieIDCommand request, CancellationToken cancellationToken)
		{
			await movieStreamRepository.DeleteStreamsByMovieID(request.MovieID);
			await unitOfWork.SaveChangesAsync();
		}
	}
}