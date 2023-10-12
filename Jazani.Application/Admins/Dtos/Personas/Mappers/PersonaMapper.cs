using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Personas.Mappers
{
    public class PersonaMapper : Profile
    {
        public PersonaMapper() 
        { 
            CreateMap<Persona, PersonaDto>();

        }
    }
}
