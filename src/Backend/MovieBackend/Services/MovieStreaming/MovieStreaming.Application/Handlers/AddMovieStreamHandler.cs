using Mapster;
using MediatR;
using MovieStreaming.Application.Commands;
using MovieStreaming.Application.DTOS;
using MovieStreaming.Application.Helper;
using MovieStreaming.Domain.Contracts;
using MovieStreaming.Domain.Entities;
using System;

namespace MovieStreaming.Application.Handlers
{
	public class AddMovieStreamHandler : IRequestHandler<AddMovieStreamCommand, GetMovieStreamDTO>
	{
		private readonly IMovieStreamRepository movieStreamRepository;
		private readonly IUnitOfWork unitOfWork;
		private readonly IFileCreationHelper fileCreationHelper;


		public AddMovieStreamHandler(IMovieStreamRepository movieStreamRepository, IUnitOfWork unitOfWork, IFileCreationHelper fileCreationHelper)
		{
			this.movieStreamRepository = movieStreamRepository;
			this.unitOfWork = unitOfWork;
			this.fileCreationHelper = fileCreationHelper;

		}
		public async Task<GetMovieStreamDTO> Handle(AddMovieStreamCommand request, CancellationToken cancellationToken)
		{
			string movieFileName = Guid.NewGuid().ToString() + ".mp4";
			var path = await fileCreationHelper.AddNewStream(request.FormMovieFile, movieFileName);
			var requestToAdd = request.Adapt<MovieStream>();
			requestToAdd.MovieFile = path;
			var result = await movieStreamRepository.AddAsync(requestToAdd);
			await unitOfWork.SaveChangesAsync();
			return result.Adapt<GetMovieStreamDTO>();
		}




	}
}
