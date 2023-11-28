using Mapster;
using MediatR;
using MovieStreaming.Application.Commands;
using MovieStreaming.Application.Helper;
using MovieStreaming.Domain.Contracts;
using MovieStreaming.Domain.Entities;

namespace MovieStreaming.Application.Handlers
{
	public class UpdateMovieStreamHandler : IRequestHandler<UpdateMovieStreamCommand>
	{
		private readonly IMovieStreamRepository movieStreamRepository;
		private readonly IUnitOfWork unitOfWork;
		private readonly IFileCreationHelper fileCreationHelper;

		public UpdateMovieStreamHandler(IMovieStreamRepository movieStreamRepository, IUnitOfWork unitOfWork, IFileCreationHelper fileCreationHelper)
		{
			this.movieStreamRepository = movieStreamRepository;
			this.unitOfWork = unitOfWork;
			this.fileCreationHelper = fileCreationHelper;
		}

		public async Task Handle(UpdateMovieStreamCommand request, CancellationToken cancellationToken)
		{
			var movieFromDB = await movieStreamRepository.GetByIdAsync(request.ID, false);
			await fileCreationHelper.AddNewStream(request.FormMovieFile, "Streams/" + Path.GetFileNameWithoutExtension(movieFromDB.MovieFile));
			await movieStreamRepository.UpdateAsync(request.Adapt<MovieStream>());
			await unitOfWork.SaveChangesAsync();
		}
	}
}