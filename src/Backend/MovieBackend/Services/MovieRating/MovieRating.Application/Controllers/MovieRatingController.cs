﻿using Microsoft.AspNetCore.Mvc;
using MovieRating.Application.DTO.MovieRating;
using MovieRating.Application.Services;

namespace MovieRating.Application.Controllers
{
	[Route("api/v1/MovieRatings")]
	[ApiController]
	public class MovieRatingController : ControllerBase
	{
		private readonly IMovieRatingService movieRatingService;

		public MovieRatingController(IMovieRatingService movieRatingService)
		{
			this.movieRatingService = movieRatingService;
		}

		[HttpGet()]
		public async Task<ActionResult<IEnumerable<GetMovieAverageRatingDTO>>> GetAllRatingsAverage()
		{
			return Ok(await movieRatingService.GetAllRatingsAverage());
		}

		[HttpGet("Movie/{MovieId}")]
		public async Task<ActionResult<IEnumerable<GetMovieRatingDTO>>> GetMovieRatings(int MovieId)
		{
			return Ok(await movieRatingService.GetRatingFromMovie(MovieId));
		}

		[HttpGet("AverageMovieRating/{MovieId}")]
		public async Task<ActionResult<GetMovieAverageRatingDTO>> GetMovieRatingAverage(int MovieId)
		{
			return Ok(await movieRatingService.GetAverageRating(MovieId));
		}
	}
}