using Microsoft.AspNetCore.Mvc;

using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Dtos;
using Jazani.Application.Generals.Dtos.NotificationTypes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTypeController : ControllerBase
    {

        private readonly INotificationTypeService _notificationTypeService;

        public NotificationTypeController(INotificationTypeService notificationTypeService)
        {
            _notificationTypeService = notificationTypeService;
        }

        // GET: api/<NotificationTypeController>
        [HttpGet]
        public async Task<IEnumerable<NotificationTypeDto>> Get()
        {
            return await _notificationTypeService.FindAllAsync();

        }

        // GET api/<NotificationTypeController>/5
        [HttpGet("{id}")]
        public async Task<NotificationTypeDto> Get(int id)
        {
            return await _notificationTypeService.FindByIdAsync(id);
        }

        // POST api/<NotificationTypeController>
        [HttpPost]
        public async Task<NotificationTypeDto> Post([FromBody] NotificationTypeSaveDto saveDto)
        {
            return await _notificationTypeService.CreateAsync(saveDto);
        }

        // PUT api/<NotificationTypeController>/5
        [HttpPut("{id}")]
        public async Task<NotificationTypeDto> Put(int id, [FromBody] NotificationTypeSaveDto saveDto)
        {
            return await _notificationTypeService.EditAsync(id, saveDto);
        }

        // DELETE api/<NotificationTypeController>/5
        [HttpDelete("{id}")]
        public async Task<NotificationTypeDto> Delete(int id)
        {
            return await _notificationTypeService.DisabledAsync(id);
        }
    }
}
