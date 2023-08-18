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
using FilmApi.DTOs.Franchise;
using FilmApi.Services;
using FilmApi.DTOs.Movie;
using FilmApi.DTOs.Character;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {


        private readonly IFranchiseService _service;
        private readonly IMapper _mapper;


        public FranchisesController(IFranchiseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Franchise
        /// <summary>
        /// Get all Franchise.
        /// </summary>
        /// <returns>An array of Franchise dtos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadFranchiseDto>>> GetFranchise()
        {
            var franchise = await _service.GetAllAsync();
            var franchiseDto = _mapper.Map<List<ReadFranchiseDto>>(franchise);

            return Ok(franchiseDto);
        }
        // GET: api/Franchise/5
        /// <summary>
        /// Get a Franchise by Id.
        /// </summary>
        /// <param name="id">The Id of the Franchise you want to fetch.</param>
        /// <returns>A Franchise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadFranchiseDto>> GetFranchise(int id)
        {
            // Use service to get album by id
            var franchise = await _service.GetByIdAsync(id);

            // Check if found item is null
            if (franchise == null)
            {
                return NotFound();
            }

            // Map domain to dto
            var franchiseDto = _mapper.Map<ReadFranchiseDto>(franchise);

            return Ok(franchiseDto);
        }


        // GET: api/Franchise/5/movies
        /// <summary>
        /// Get all movies in a Franchise.
        /// </summary>
        /// <param name="id">The Id of the Franchise whose movies you want to fetch.</param>
        /// <returns>An array of movie dtos.</returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<ReadMovieDto>>> GetMoviesInFranchise(int id)
        {
            // Use service to get album by id
            var franchise = await _service.GetByIdAsync(id);

            // Check if found item is null
            if (franchise == null)
            {
                return NotFound();
            }

            franchise = await _service.IncludeMovies(id);

            var moviesDto = _mapper.Map<List<ReadMovieDto>>(franchise.movies);


            return Ok(moviesDto);
        }

        // GET: api/Franchise/5/characters
        /// <summary>
        /// Get all characters in a Franchise.
        /// </summary>
        /// <param name="id">The Id of the Franchise whose characters you want to fetch.</param>
        /// <returns>An array of character dtos.</returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<ReadCharacterDto>>> GetCharactersInFranchise(int id)
        {
            var franchise = await _service.IncludeCharacters(id);

            if (franchise == null)
            {
                return NotFound();
            }

            Console.WriteLine(franchise);


            var franchiseCharacters = _service.GetCharacterInFranchise(franchise);

            Console.WriteLine(franchiseCharacters);

            var franchiseCharactersDto = _mapper.Map<List<ReadCharacterDto>>(franchiseCharacters);


            return Ok(franchiseCharactersDto);
        }


        // PUT: api/Franchises/5
        /// <summary>
        /// Update a Franchise.
        /// </summary>
        /// <param name="id">The Id of the Franchise you want to update.</param>
        /// <param name="labelDto">The updated Franchise object.</param>
        /// <returns>An Http status code depending on the outcome of the transaction.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, UpdateFranchiseDto franchiseDto)
        {
            // Map dto to domain object
            var franchise = _mapper.Map<Franchise>(franchiseDto);

            try
            {
                await _service.UpdateAsync(franchise);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await FranchiseExistsAsync(id))
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

        // POST: api/Franchise
        /// <summary>
        /// Add a new Franchise.
        /// </summary>
        /// <param name="franchiseDto">The new Franchise object.</param>
        /// <returns>sThe newly created Franchise.</returns>
        [HttpPost]
        public async Task<ActionResult<ReadFranchiseDto>> PostFranchise(CreateFranchiseDto franchiseDto)
        {
            // Map dto to domain object
            var franchise = _mapper.Map<Franchise>(franchiseDto);
            var franchiseId = await _service.AddAsync(franchise);

            return CreatedAtAction("GetFranchise", franchiseId, franchiseDto);
        }

        // PUT: api/Franchises/5
        /// <summary>
        /// Update the Movies in a Franchise.
        /// </summary>
        /// <param name="id">The Id of the Franchise whose Movies you want to update.</param>
        /// <param name="movieIds">A list of Ids of the Movies belonging to the Franchise.</param>
        /// <returns></returns>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateFranchiseMovies(int id, [FromBody] IEnumerable<int> movieIds)
        {
            var franchise = await _service.GetByIdAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            await _service.UpdateMoviesOnFranchise(franchise, movieIds);

            return Ok();
        }

        // DELETE: api/franchise/5
        /// <summary>
        /// Delete a Franchise.
        /// </summary>
        /// <param name="id">The Id of the Franchise you want to delete.</param>
        /// <returns>An Http status code depending on the outcome of the transaction.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
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


        /// <summary>
        /// Checks if Franchise with specfied id exist in Db Context
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True/False if Franchise Do exist/Dont exist</returns>
        private async Task<bool> FranchiseExistsAsync(int id)
        {
            return await _service.ExistsWithIdAsync(id);
        }

    }
}
