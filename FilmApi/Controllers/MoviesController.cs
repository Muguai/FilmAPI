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

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;


        public MoviesController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadMovieDto>>> GetCharacter()
        {
            var Movie = await _service.GetAllAsync();
            var MovieDto = _mapper.Map<List<ReadMovieDto>>(Movie);

            return Ok(MovieDto);
        }


        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadMovieDto>> GetMovie(int id)
        {
            // Use service to get album by id
            var Movie = await _service.GetByIdAsync(id);

            // Check if found item is null
            if (Movie == null)
            {
                return NotFound();
            }

            // Map domain to dto
            var MovieDto = _mapper.Map<ReadMovieDto>(Movie);

            return Ok(MovieDto);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
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
        // POST: api/Movie
        [HttpPost]
        public async Task<ActionResult<ReadMovieDto>> PostMovie(CreateMovieDto MovieDto)
        {
            // Map dto to domain object
            var Movie = _mapper.Map<Movie>(MovieDto);
            var MovieId = await _service.AddAsync(Movie);

            return CreatedAtAction("GetMovie", MovieId, MovieDto);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
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

            await _service.DeleteAsync(deletedEntity);

            return NoContent();
        }


        private async Task<bool> MovieExistsAsync(int id)
        {
            return await _service.ExistsWithIdAsync(id);
        }
    }
}
