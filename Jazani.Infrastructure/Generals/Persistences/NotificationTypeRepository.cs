using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.EntityFrameworkCore;
using Jazani.Infrastructure.Cores.Persistences;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class NotificationTypeRepository : CrudRepository<NotificationType, int>, INotificationTypeRepository
    {
        public NotificationTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
