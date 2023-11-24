using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieStreaming.Application.Commands;
using MovieStreaming.Application.DTOS;
using MovieStreaming.Application.Querries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStreaming.Application.Controllers
{
	[Route("api/v1/moviestreams")]
	[ApiController]
	public class MovieStreamController : ControllerBase
	{
		private readonly IMediator mediator;

		public MovieStreamController(IMediator mediator)
		{
			this.mediator = mediator;
		}
	
		[HttpGet]
		public async Task<IEnumerable<GetMovieStreamDTO>> Get()
		{
			return await mediator.Send(new GetMovieStreamsQuerry());
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<GetMovieStreamDTO>> Get(int id)
		{
			var result = await mediator.Send(new GetMovieStreamByIdQuerry(id));
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpGet("GetMovieStreamByMovieID/{id}")]
		public async Task<ActionResult<GetMovieStreamDTO>> GetMovieStreamByMovieID(int id)
		{
			var result = await mediator.Send(new GetMovieStreambyMovieIdQuerry(id));
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromForm] AddMovieStreamDTO value)
		{
			var result = await mediator.Send(new AddMovieStreamCommand(value.MovieID, value.FormMovieFile));
			return Ok(result);

		}

		[HttpPut()]
		public async Task<ActionResult> Put([FromForm] UpdateMovieStreamDTO value)
		{
			await mediator.Send(new UpdateMovieStreamCommand(value.ID, value.FormMovieFile));
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await mediator.Send(new DeleteMovieStreamCommand(id));
			return Ok();
		}
	}
}
