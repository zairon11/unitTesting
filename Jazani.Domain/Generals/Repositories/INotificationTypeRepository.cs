using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Domain.Cores.Repositories;


namespace Jazani.Domain.Generals.Repositories
{
    public interface INotificationTypeRepository : ICrudRepository<NotificationType, int>
    {
        
         
    }
}
