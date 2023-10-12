using Jazani.Application.Generals.Dtos.NotificationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services
{
    public interface INotificationTypeService
    {
        Task<IReadOnlyList<NotificationTypeDto>> FindAllAsync();
        Task<NotificationTypeDto?> FindByIdAsync(int id);
        Task<NotificationTypeDto> CreateAsync(NotificationTypeSaveDto saveDto);
        Task<NotificationTypeDto> EditAsync(int id, NotificationTypeSaveDto saveDto);
        Task<NotificationTypeDto> DisabledAsync(int id);
    }
}
