using System;
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
        [HttpPost]
        public async Task<ActionResult<ReadCharacterDto>> PostCharacter(CreateCharacterDto characterDto)
        {
            // Map dto to domain object
            var character = _mapper.Map<Character>(characterDto);
            var characterId = await _service.AddAsync(character);

            return CreatedAtAction("GetCharacter", characterId, characterDto);
        }

        // DELETE: api/character/5
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

        private async Task<bool> CharacterExistsAsync(int id)
        {
            return await _service.ExistsWithIdAsync(id);
        }


    }
}
