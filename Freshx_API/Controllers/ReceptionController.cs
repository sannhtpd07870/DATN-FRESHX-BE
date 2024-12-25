using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.IReception;
using Freshx_API.Models;
using Freshx_API.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionController : ControllerBase
    {
        private readonly IReceptionService _service;

        public ReceptionController(IReceptionService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reception = await _service.GetByIdAsync(id);
            return reception == null ? NotFound() : Ok(reception);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var receptions = await _service.GetAllAsync();
            return Ok(receptions);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateReceptionDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateReceptionDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }


}
