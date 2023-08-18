﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmApi.Data_Access;
using FilmApi.Models;
using FilmApi.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;

using FilmApi.DTOs.Character;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {

        private readonly ICharacterService _service;
        private readonly IMapper _mapper;


        public CharactersController(ICharacterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCharacterDto>>> GetCharacter()
        {
            var character = await _service.GetAllAsync();
            var characterDto = _mapper.Map<List<ReadCharacterDto>>(character);

            return Ok(characterDto);
        }


        // GET: api/Characters/5
        /// <summary>
        /// Get a Character by Id.
        /// </summary>
        /// <param name="id">The Id of the Character you want to fetch.</param>
        /// <returns>A Label.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCharacterDto>> GetCharacter(int id)
        {
            // Use service to get album by id
            var character = await _service.GetByIdAsync(id);

            // Check if found item is null
            if (character == null)
            {
                return NotFound();
            }

            // Map domain to dto
            var characterDto = _mapper.Map<ReadCharacterDto>(character);

            return Ok(characterDto);
        }

        // PUT: api/Characters/5
        /// <summary>
        /// Update a Character.
        /// </summary>
        /// <param name="id">The Id of the Character you want to update.</param>
        /// <param name="characterDto">The updated Character object.</param>
        /// <returns>An Http status code depending on the outcome of the transaction.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, UpdateCharacterDto characterDto)
        {
            // Map dto to domain object
            var character = _mapper.Map<Character>(characterDto);

            try
            {
                await _service.UpdateAsync(character);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CharacterExistsAsync(id))
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
        // POST: api/Characters

        /// <summary>
        /// Add a new Character.
        /// </summary>
        /// <param name="characterDto">The new Character object.</param>
        /// <returns>sThe newly created Character.</returns>
        [HttpPost]
        public async Task<ActionResult<ReadCharacterDto>> PostCharacter(CreateCharacterDto characterDto)
        {
            // Map dto to domain object
            var character = _mapper.Map<Character>(characterDto);
            var characterId = await _service.AddAsync(character);

            return CreatedAtAction("GetCharacter", characterId, characterDto);
        }

        // DELETE: api/Character/5
        /// <summary>
        /// Delete a Character.
        /// </summary>
        /// <param name="id">The Id of the Character you want to delete.</param>
        /// <returns>An Http status code depending on the outcome of the transaction.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
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
        /// Checks if character with specfied id exist in Db Context
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True/False if character Do exist/Dont exist</returns>
        private async Task<bool> CharacterExistsAsync(int id)
        {
            return await _service.ExistsWithIdAsync(id);
        }


    }
}
