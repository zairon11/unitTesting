using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.NotificationTypes.Profiles
{
    public class MineralTypeProfile : Profile
    {
        public MineralTypeProfile()
        {
            CreateMap<NotificationType, NotificationTypeDto>();
            CreateMap<NotificationType, NotificationTypeDto>().ReverseMap();
        }
    }
}
