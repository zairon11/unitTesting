using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jazani.Application.Admins.Dtos.Personas;

namespace Jazani.Application.Admins.Services
{
    public interface IPersonaService
    {
        Task<IReadOnlyList<PersonaDto>> FindAllAsync();
        Task<PersonaDto?> FindByIdAsync(int id);
        Task<PersonaDto> CreateAsync(PersonaSaveDto personaSaveDto);
        Task<PersonaDto> EditAsync(int id, PersonaSaveDto personaSaveDto);
        Task<PersonaDto> DisabledAsync(int id);
    }
}
