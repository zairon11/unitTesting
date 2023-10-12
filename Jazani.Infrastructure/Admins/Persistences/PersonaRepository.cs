using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;


namespace Jazani.Infrastructure.Admins.Persistences
{
    public class PersonaRepository : CrudRepository<Persona, int>, IPersonaRepository
    {
        public PersonaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
