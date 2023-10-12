using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using AutoFixture;
using AutoMapper;
using Jazani.Application.Generals.Dtos.NotificationTypes;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Domain.Admins.Repositories;
using Jazani.Application.Generals.Dtos.NotificationTypes.Profiles;
using Microsoft.VisualBasic;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class NotificationTypeServiceTest
    {
        Mock<INotificationTypeRepository> _mockNotificationTypeRepository = new Mock<INotificationTypeRepository>();
        IMapper _mapper;
        Fixture _fixture;
        public NotificationTypeServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MineralTypeProfile>();
            });
            _fixture = new Fixture();
            _mapper = mapperConfiguration.CreateMapper();
            _mockNotificationTypeRepository = new Mock<INotificationTypeRepository>();
        }

       

        [Fact]
        public async void returnNotificationTypeDtoWhenFindByIdAsync()
        {

        }

        [Fact]
        public async void returnNotificationTypesDtoWhenFindAllAsync()
        {

        }

        [Fact]
        public async void returnNotificationTypeDtoWhenCreateAsync()
        {
            NotificationType notificationType = new()
            {
                // arrage
                Id = 1,
                Name = "Monitoreo de concesiones",
                Description = "",
                State = true,
                RegistrationDate = DateTime.Now,


            };

            _mockNotificationTypeRepository
                .Setup(r => r.SaveAsync(It.IsAny<NotificationType>()))
                .ReturnsAsync(notificationType);

            // act
            NotificationTypeSaveDto notificationTypeSaveDto = new()
            {
                Name = notificationType.Name,
                Description = notificationType.Description,


            };

            INotificationTypeService notificationTypeService = new NotificationTypeService(_mockNotificationTypeRepository.Object, _mapper);

            NotificationTypeDto notificationTypeDto = await notificationTypeService.CreateAsync(notificationTypeSaveDto);

            // assert
            Assert.Equal(notificationType.Name, notificationTypeDto.Name);
        }

        // editar
        [Fact]
        public async void returnNotificationTypeDtoWhenEditAsync()
        {
            int id = 1;
            NotificationType notificationType = new()
            {
                // arrage
                Id = id,
                Name = "Monitoreo de concesiones",
                Description = "",
                State = true,
                RegistrationDate = DateTime.Now,


            };

            _mockNotificationTypeRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(notificationType);

            _mockNotificationTypeRepository
                .Setup(r => r.SaveAsync(It.IsAny<NotificationType>()))
                .ReturnsAsync(notificationType);

            
            // act
            NotificationTypeSaveDto notificationTypeSaveDto = new()
            {
                Name = notificationType.Name,
                Description = notificationType.Description,


            };

            INotificationTypeService notificationTypeService = new NotificationTypeService(_mockNotificationTypeRepository.Object, _mapper);

            NotificationTypeDto notificationTypeDto = await notificationTypeService.EditAsync(id,notificationTypeSaveDto);

            // assert
            Assert.Equal(notificationType.Id, notificationTypeDto.Id);
        }

        // editar
        [Fact]
        public async void returnNotificationTypeDtoWhenDisabledAsync()
        {
            int id = 1;
            NotificationType notificationType = new()
            {
                // arrage
                Id = id,
                Name = "Monitoreo de concesiones",
                Description = "",
                State = false,
                RegistrationDate = DateTime.Now,


            };

            _mockNotificationTypeRepository
               .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
               .ReturnsAsync(notificationType);

            _mockNotificationTypeRepository
                .Setup(r => r.SaveAsync(It.IsAny<NotificationType>()))
                .ReturnsAsync(notificationType);

           
            // act
          

            INotificationTypeService notificationTypeService = new NotificationTypeService(_mockNotificationTypeRepository.Object, _mapper);

            NotificationTypeDto notificationTypeDto = await notificationTypeService.DisabledAsync(id);

            // assert
            Assert.Equal(notificationType.State, notificationTypeDto.State);
        }

    }
}
