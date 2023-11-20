using System;

namespace MovieStreaming.Application.Helper
{
	public class FileCreationHelper : IFileCreationHelper
	{
		private readonly IWebHostEnvironment environment;

		public FileCreationHelper(IWebHostEnvironment environment)
		{
			this.environment = environment;
		}

		public async Task<string> AddNewStream(IFormFile formFile, string FileName)
		{
			var uniqueFileName = FileName;
			var filePath = Path.Combine(UploadFolder, uniqueFileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await formFile.CopyToAsync(stream);
			}
			return $"/{uniqueFileName}";
		}

		private string UploadFolder
		{
			get
			{
				return Path.Combine(environment.WebRootPath);
			}
		}
	}
}
