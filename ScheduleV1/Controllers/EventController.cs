using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedule.API.V1.Dtos;
using Schedule.Domain.Entities.ScheduleAggregation.Exception;
using Schedule.Domain.Entities.ScheduleAggregation.Services;

namespace Schedule.API.V1.Controllers
{
    [Authorize("Bearer")]
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        private readonly IValidator<CreateEventDto> _validator;
        private readonly IEventService _eventService;

        public EventController(IValidator<CreateEventDto> validator, IEventService eventService)
        {
            _validator = validator;
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var @event = _eventService.GetAllEvent();
            return Ok(@event);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
        {
            var validateResult = _validator.Validate(dto);

            if (validateResult.IsValid)
            {
                try
                {
                    await _eventService.CreateEvent(dto.Name, dto.Description, dto.Date, dto.Locality, dto.Participants,
                        dto.EventType, dto.ScheduleId);

                    return Ok();
                }
                catch (ExclusiveEventOverlayException e)
                {
                    return BadRequest(e.Message);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return Conflict(validateResult.Errors);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEvent([FromRoute] Guid id, [FromBody] CreateEventDto dto)
        {
            if (id == Guid.Empty) return BadRequest();

            var validateResult = _validator.Validate(dto);

            if (validateResult.IsValid)
            {
                await _eventService.UpdateEvent(id, dto.Name, dto.Description, dto.Date, dto.Locality, dto.Participants, dto.EventType);

                return Ok();
            }

            return BadRequest(validateResult.Errors);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> ActiveEvent([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            
            await _eventService.ActivateEvent(id);

            return Ok();

        }
    }
}
