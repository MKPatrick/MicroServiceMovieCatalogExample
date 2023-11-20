
namespace MovieStreaming.Application.Helper
{
	public interface IFileCreationHelper
	{
		Task<string> AddNewStream(IFormFile formFile, string FileName);
	}
}