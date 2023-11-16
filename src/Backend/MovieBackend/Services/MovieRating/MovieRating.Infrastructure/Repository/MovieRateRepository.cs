using Microsoft.EntityFrameworkCore;
using MovieRating.Domain.Contracts;
using MovieRating.Domain.Entities;
using MovieRating.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Infrastructure.Repository
{
	public class MovieRateRepository : IMovieRatingRepository
	{
		private readonly MovieRatingDatabaseContext movieRatingDatabaseContext;

		public MovieRateRepository(MovieRatingDatabaseContext movieRatingDatabaseContext)
        {
			this.movieRatingDatabaseContext = movieRatingDatabaseContext;
		}
        public  IQueryable<MovieRate> GetRatesFromMovie(int MovieID)
		{
			return movieRatingDatabaseContext.MovieRates.Where(x => x.MovieID == MovieID);
		}

		public IQueryable<MovieRate> GetAllRates()
		{
			return movieRatingDatabaseContext.MovieRates;
		}
	}
}
