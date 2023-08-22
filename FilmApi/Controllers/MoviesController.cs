using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmApi.Data_Access;
using FilmApi.Models;
using AutoMapper;
using FilmApi.DTOs.Movie;
using FilmApi.Services;
using FilmApi.DTOs.Character;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;


        public MoviesController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Movies
        /// <summary>
        /// Get all movies.
        /// </summary>
        /// <returns>An array of movie dtos.</returns>

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ReadMovieDto>>> GetMovie()
        {
            var Movie = await _service.GetAllAsync();
            var MovieDto = _mapper.Map<List<ReadMovieDto>>(Movie);

            return Ok(MovieDto);
        }


        // GET: api/Movies/5
        /// <summary>
        /// Get a Movie by Id.
        /// </summary>
        /// <param name="id">The Id of the Movie you want to fetch.</param>
        /// <returns>A Movie Dto.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ReadMovieDto>> GetMovie(int id)
        {
            var Movie = await _service.GetByIdAsync(id);

            if (Movie == null)
            {
                return NotFound();
            }

            var MovieDto = _mapper.Map<ReadMovieDto>(Movie);

            return Ok(MovieDto);
        }

        // PUT: api/Movies/5
        /// <summary>
        /// Update a Movie.
        /// </summary>
        /// <param name="id">The Id of the Movie you want to update.</param>
        /// <param name="MovieDto">The updated Movie object.</param>
        /// <returns>An Http status code depending on the outcome of the transaction.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutMovie(int id, UpdateMovieDto MovieDto)
        {
            // Map dto to domain object
            var Movie = _mapper.Map<Movie>(MovieDto);

            try
            {
                await _service.UpdateAsync(Movie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MovieExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // PUT: api/Movies/3/characters
        /// <summary>
        /// Update the Characters in a Movie.
        /// </summary>
        /// <param name="id">The Id of the Movie whose Characters you want to update.</param>
        /// <param name="characterIds">A list of Ids of the Characters belonging to the Movie.</param>
        /// <returns></returns>
        [HttpPut("{id}/characters")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateMovieCharacters(int id, [FromBody] IEnumerable<int> characterIds)
        {
            var movie = await _service.IncludeCharacterMovieAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            await _service.UpdateCharactersInMovieAsync(movie, characterIds);

            return Ok();
        }

        // GET: api/Movies/3/characters
        /// <summary>
        /// Get all the Characters in a movie
        /// </summary>
        /// <param name="id">The Id of the Movie whose Characters you want to get.</param>
        /// <returns>List of character dtos</returns>
        [HttpGet("{id}/characters")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<ReadCharacterDto>>> GetAllCharactersInMovie(int id)
        {

            var movie = await _service.IncludeCharacterMovieAsync(id);

            if (movie == null)
            {
                return NotFound();
            }


            var characters = await _service.getAllCharactersInMovieAsync(movie);
            var CharacterDto = _mapper.Map<List<ReadCharacterDto>>(characters);

            return Ok(CharacterDto);
        }


        // POST: api/Movie
        /// <summary>
        /// Add a new Movie.
        /// </summary>
        /// <param name="MovieDto">The new Movie object.</param>
        /// <returns>sThe newly created Movie.</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<ReadMovieDto>> PostMovie(CreateMovieDto MovieDto)
        {
            var Movie = _mapper.Map<Movie>(MovieDto);
            var MovieId = await _service.AddAsync(Movie);

            return CreatedAtAction("GetMovie", MovieId, MovieDto);
        }

        // DELETE: api/Movie/5
        /// <summary>
        /// Delete a Movie.
        /// </summary>
        /// <param name="id">The Id of the Movie you want to delete.</param>
        /// <returns>An Http status code depending on the outcome of the transaction.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!await _service.ExistsWithIdAsync(id))
            {
                return NotFound();
            }

            var deletedEntity = await _service.GetByIdAsync(id);

            if (deletedEntity == null)
            {
                return NotFound();
            }


            await _service.DeleteCharacterMovieAsync(id);

            await _service.DeleteAsync(deletedEntity);
            


            return NoContent();
        }

        /// <summary>
        /// Checks if movie with specfied id exist in Db Context
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True/False if movie Do exist/Dont exist</returns>
        private async Task<bool> MovieExistsAsync(int id)
        {
            return await _service.ExistsWithIdAsync(id);
        }
    }
}
