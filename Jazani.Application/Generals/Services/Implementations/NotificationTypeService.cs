using Jazani.Application.Generals.Dtos.NotificationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;


namespace Jazani.Application.Generals.Services.Implementations
{
    public class NotificationTypeService : INotificationTypeService
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IMapper _mapper;
       

        public NotificationTypeService(INotificationTypeRepository notificationTypeRepository, IMapper mapper)
        {
            _notificationTypeRepository = notificationTypeRepository;
            _mapper = mapper;
        }
        public async Task<NotificationTypeDto> CreateAsync(NotificationTypeSaveDto saveDto)
        {
            NotificationType notificationType = _mapper.Map<NotificationType>(saveDto);
            notificationType.RegistrationDate= DateTime.Now;
            notificationType.State = true;
            await _notificationTypeRepository.SaveAsync(notificationType);

            return _mapper.Map<NotificationTypeDto>(notificationType);
        }

        public async Task<NotificationTypeDto> DisabledAsync(int id)
        {
            NotificationType notificationType = await _notificationTypeRepository.FindByIdAsync(id);
            notificationType.State = false;
            await _notificationTypeRepository.SaveAsync(notificationType);

            return _mapper.Map<NotificationTypeDto>(notificationType);
        }

        public async Task<NotificationTypeDto> EditAsync(int id, NotificationTypeSaveDto saveDto)
        {
            NotificationType notificationType = await _notificationTypeRepository.FindByIdAsync(id);
            _mapper.Map<NotificationTypeSaveDto, NotificationType>(saveDto, notificationType);
            await _notificationTypeRepository.SaveAsync(notificationType);

            return _mapper.Map<NotificationTypeDto>(notificationType);
        }

        public async Task<IReadOnlyList<NotificationTypeDto>> FindAllAsync()
        {
            IReadOnlyList<NotificationType> notificationTypes = await _notificationTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<NotificationTypeDto>>(notificationTypes);

        }

        public async Task<NotificationTypeDto?> FindByIdAsync(int id)
        {
            NotificationType notificationType = await _notificationTypeRepository.FindByIdAsync(id);
            

            return _mapper.Map<NotificationTypeDto>(notificationType);
        }
    }
}
