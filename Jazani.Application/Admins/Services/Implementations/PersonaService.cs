using Jazani.Application.Admins.Dtos.Personas;
using Jazani.Domain.Admins.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jazani.Domain.Admins.Models;
using AutoMapper;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper) 
        { 
            _personaRepository= personaRepository;
            _mapper= mapper;
        }


        public async Task<IReadOnlyList<PersonaDto>> FindAllAsync()
        {
            IReadOnlyList<Persona> personas = await _personaRepository.FindAllAsync();
            
            return _mapper.Map<IReadOnlyList<PersonaDto>>(personas);
            
        }

        public async Task<PersonaDto?> FindByIdAsync(int id)
        {
            Persona? persona = await _personaRepository.FindByIdAsync(id);
            return _mapper.Map<PersonaDto>(persona);
        }

        public async  Task<PersonaDto> CreateAsync(PersonaSaveDto personaSaveDto)
        {
            Persona persona = _mapper.Map<Persona>(personaSaveDto);
            persona.RegistrationDate = DateTime.Now;
            persona.State = true;
            Persona personaSaved = await _personaRepository.SaveAsync(persona);

            return _mapper.Map<PersonaDto>(personaSaved);
        }

        public async  Task<PersonaDto> DisabledAsync(int id)
        {
            Persona persona = await _personaRepository.FindByIdAsync(id);
            persona.State = false;
            Persona personaSaved = await _personaRepository.SaveAsync(persona);
            return _mapper.Map<PersonaDto>(personaSaved);
        }

        public async  Task<PersonaDto> EditAsync(int id, PersonaSaveDto personaSaveDto)
        {
            Persona persona = await _personaRepository.FindByIdAsync(id);
            _mapper.Map<PersonaSaveDto, Persona>(personaSaveDto, persona);
            Persona personaSaved = await _personaRepository.SaveAsync(persona);

            return _mapper.Map<PersonaDto>(personaSaved);
        }

    }
}
