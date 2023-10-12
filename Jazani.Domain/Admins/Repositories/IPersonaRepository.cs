﻿using Jazani.Domain.Admins.Models;
using Jazani.Domain.Cores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IPersonaRepository : ICrudRepository<Persona, int>
    {
        

    }
}
