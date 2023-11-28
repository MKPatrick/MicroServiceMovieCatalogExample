using Mapster;
using MovieCatalog.Application.DTO.Movie;
using MovieCatalog.Application.Helper;
using MovieCatalog.Application.Messaging;
using MovieCatalog.Domain.Contracts;
using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Application.Services
{
	public class MovieService : IMovieService
	{
		private readonly IMovieRepository movieRepository;
		private readonly IUnitOfWork unitOfWork;
		private readonly IWebHostEnvironment environment;
		private readonly IMovieDeleteProduce movieDeleteProduce;

		public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork, IWebHostEnvironment environment, IMovieDeleteProduce movieDeleteProduce)
		{
			this.movieRepository = movieRepository;
			this.unitOfWork = unitOfWork;
			this.environment = environment;
			this.movieDeleteProduce = movieDeleteProduce;
		}

		public async Task<GetMovieDTO> GetMovie(int id)
		{
			var result = await movieRepository.GetByIdAsync(id);
			result = SetPlaceHolderImageWhenNoImageIsSet(result);
			return result.Adapt<GetMovieDTO>();
		}

		public async Task<IEnumerable<GetMovieDTO>> GetAllMovies()
		{
			var result = await movieRepository.GetAllAsync();
			result = result.Select(x => x = SetPlaceHolderImageWhenNoImageIsSet(x));
			return result.Adapt<IEnumerable<GetMovieDTO>>();
		}

		public async Task<GetMovieDTO> AddMovie(AddMovieDTO addMovieDTO)
		{
			var movieToAdd = addMovieDTO.Adapt<Movie>();
			if (addMovieDTO.MovieImage != null)
			{
				string movieImagePath = await SaveImage(addMovieDTO.MovieImage, Guid.NewGuid().ToString() + ".jpg");
				movieToAdd.MovieImage = movieImagePath;
			}
			var result = await movieRepository.AddAsync(movieToAdd);
			await unitOfWork.SaveChangesAsync();
			return result.Adapt<GetMovieDTO>();
		}

		public async Task DeleteMovie(int id)
		{
			try
			{
				var imageURL = (await movieRepository.GetByIdAsync(id, false)).MovieImage;
				if (String.IsNullOrEmpty(imageURL) == false)
				{
					string fileToDelet = $"{UploadFolder}\\{Path.GetFileName(imageURL)}";
					File.Delete(fileToDelet);
				}
				await movieRepository.DeleteAsync(id);
				await unitOfWork.SaveChangesAsync();
				movieDeleteProduce.SendMovieDeleteProduce(id);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public async Task UpdateMovie(UpdateMovieDTO updateMovieDTO)
		{
			Movie movieToUpdate = updateMovieDTO.Adapt<Movie>();
			//new Image - replace the old one!
			if (updateMovieDTO.MovieImage != null)
			{
				var movieFromDB = await movieRepository.GetByIdAsync(updateMovieDTO.ID);
				//has stilll default image... new filename and replace it
				if (String.IsNullOrEmpty(movieFromDB.MovieImage))
				{
					string updatedImagePath = await SaveImage(updateMovieDTO.MovieImage, Guid.NewGuid().ToString() + ".jpg");
					movieToUpdate.MovieImage = updatedImagePath;
				}
				else
				{
					//replace existing one
					await SaveImage(updateMovieDTO.MovieImage, Path.GetFileName(movieFromDB.MovieImage));
				}
			}
			await movieRepository.UpdateAsync(movieToUpdate);
			await unitOfWork.SaveChangesAsync();
		}

		public Movie SetPlaceHolderImageWhenNoImageIsSet(Movie movie)
		{
			if (String.IsNullOrEmpty(movie.MovieImage))
				movie.MovieImage = Consts.NoMovieImageTemplate;
			return movie;
		}

		private async Task<string> SaveImage(IFormFile formFile, string FileName)
		{
			var uniqueFileName = FileName;
			var filePath = Path.Combine(UploadFolder, uniqueFileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await formFile.CopyToAsync(stream);
			}
			return $"/MovieImages/{uniqueFileName}";
		}

		private string UploadFolder
		{
			get
			{
				return Path.Combine(environment.WebRootPath, "MovieImages");
			}
		}
	}
}