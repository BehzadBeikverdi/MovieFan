using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieFan.Data;
using MovieFan.IRepository;
using MovieFan.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MovieFan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MovieController> _logger;
        private readonly IMapper _mapper;

        public MovieController(IUnitOfWork unitOfWork,
            ILogger<MovieController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                var movies = await _unitOfWork.Movies.GetAllMovies();
                var results = _mapper.Map<IList<MovieDTO>>(movies);


                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetMovies)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                var movie = await _unitOfWork.Movies.GetById(i => i.Id == id, new List<string> { "Movies" });
                var result = _mapper.Map<MovieDTO>(movie);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Sth went wrong in the {nameof(GetMovieById)}");
                return StatusCode(500, "Internal server error. Please try again later.");

            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddMovie([FromBody] MovieDTO movieDTO)
        {
            _logger.LogInformation($"Add Movie attempts for {movieDTO.MovieName}");
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var movie = _mapper.Map<Movie>(movieDTO);
                await _unitOfWork.Movies.InsertMovie(movie);
                await _unitOfWork.Save();

                return Ok("Data Added!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Something went wrong in the {nameof(AddMovie)}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Movie>> DeleteMovieById(int id)
        {
            try
            {
                await _unitOfWork.Movies.DeleteMovieById(id);
                var saved = await _unitOfWork.Save();

                var response = new GenericResponseDTO
                {
                    IsSuccessful = saved > 0,
                    StatusCode = saved > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                    Result = saved > 0 ? $"Delete Movie Successfully." : $"Delete Movie Failed!"
                };


                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new GenericResponseDTO
                {
                    IsSuccessful = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Result = "Sth went wrong!"
                };


                return NotFound(response);
            }
        }
    }
}
