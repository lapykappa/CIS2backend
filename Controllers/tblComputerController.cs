using DbFirstCIS2.DATA;
using DbFirstCIS2.DTO;
using DbFirstCIS2.Models;
using DbFirstCIS2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbFirstCIS2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly ITblComputerRepository _repository;
        public ComputersController(ITblComputerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ComputerDto>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComputerDto>> Get(int id)
        {
            var computer = await _repository.GetAsync(id);
            if (computer == null)
                return NotFound();

            return computer;
        }

        [HttpPost]
        public async Task<ActionResult<ComputerDto>> Create(ComputerDto computerDto)
        {
            var createdComputer = await _repository.CreateAsync(computerDto);
            return CreatedAtAction(nameof(Get), new { id = createdComputer.Id }, createdComputer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ComputerDto computerDto)
        {
            if (id != computerDto.Id)
                return BadRequest();

            await _repository.UpdateAsync(computerDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var computer = await _repository.GetAsync(id);
            if (computer == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}