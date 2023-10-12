using Microsoft.AspNetCore.Mvc;

using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Application.Admins.Services;
using Jazani.Application.Admins.Dtos.Personas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        private readonly IPersonaService _personaService;


        public PersonaController(IPersonaService personaService)
        {
            _personaService= personaService;
        }


        // GET: api/<PersonaController>
        [HttpGet]
        public  async Task<IEnumerable<PersonaDto>> Get()
        {
            return await _personaService.FindAllAsync();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public async Task<PersonaDto> Get(int id)
        {
            return await _personaService.FindByIdAsync(id);
        }

        // POST api/<PersonaController>
        [HttpPost]
        public async Task<PersonaDto> Post([FromBody] PersonaSaveDto personaSaveDto)
        {
            return await _personaService.CreateAsync(personaSaveDto);
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public async Task<PersonaDto> Put(int id, [FromBody] PersonaSaveDto personaSaveDto)
        {
            return await _personaService.EditAsync(id, personaSaveDto);
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public async Task<PersonaDto> Delete(int id)
        {
            return await _personaService.DisabledAsync(id);
        }
    }
}
