using Api.Core.Bussines;
using Api.Core.Dtos;
using Api.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaService _service;

        public PersonasController(IPersonaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonaDto persona)
        {
            var response = await _service.AddAsync(persona);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonaDto persona)
        {
            var response = await _service.UpdateAsync(persona);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}
