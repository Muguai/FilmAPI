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

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadFranchiseDto>>> GetCharacter()
        {
            var franchise = await _service.GetAllAsync();
            var franchiseDto = _mapper.Map<List<ReadFranchiseDto>>(franchise);

            return Ok(franchiseDto);
        }


        // GET: api/Characters/5
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

        // PUT: api/Franchises/5
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
        [HttpPost]
        public async Task<ActionResult<ReadFranchiseDto>> PostFranchise(CreateFranchiseDto franchiseDto)
        {
            // Map dto to domain object
            var franchise = _mapper.Map<Franchise>(franchiseDto);
            var franchiseId = await _service.AddAsync(franchise);

            return CreatedAtAction("GetFranchise", franchiseId, franchiseDto);
        }

        // DELETE: api/franchise/5
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


        private async Task<bool> FranchiseExistsAsync(int id)
        {
            return await _service.ExistsWithIdAsync(id);
        }

    }
}
