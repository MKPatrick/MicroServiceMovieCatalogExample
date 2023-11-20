using MovieStreaming.Domain.Entities;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Domain.Contracts
{
	public interface IMovieStreamRepository : IBaseRepository<MovieStream>
	{
		Task DeleteStreamsByMovieID(int movieID);
		Task<MovieStream?> GetStreamForMovieID(int movieID);
	}
}
