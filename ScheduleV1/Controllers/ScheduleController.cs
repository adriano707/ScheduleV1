using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedule.API.V1.Dtos;
using Schedule.Domain.Entities.ScheduleAggregation.Services;

namespace Schedule.API.V1.Controllers
{
    [Authorize("Bearer")]
    [ApiController]
    [Route("schedules")]
    public class ScheduleController : ControllerBase
    {
        private readonly IValidator<ScheduleDto> _validator;
        private readonly IScheduleService _service;
        public ScheduleController(IValidator<ScheduleDto> validator, IScheduleService service)
        {
            _validator = validator;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var schedule = _service.GetAllSchedule();
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] ScheduleDto dto)
        {
            var validateResult = _validator.Validate(dto);

            if (validateResult.IsValid)
            {
                var schedule = await _service.CreateSchedule(dto.Name, dto.Description);

                return Ok(schedule);
            }

            return Conflict(validateResult.Errors);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpadetSchedule([FromRoute] Guid id, [FromBody] ScheduleDto scheduleDto)
        {
            if (id == Guid.Empty) return BadRequest();

            var validateResult = _validator.Validate(scheduleDto);

            if (validateResult.IsValid)
            {
                await _service.UpdateSchedule(id, scheduleDto.Name, scheduleDto.Description);

                return Ok();
            }

            return BadRequest(validateResult.Errors);
        }

        [HttpPost]
        [Route("{id}/events/add")]
        public async Task<IActionResult> AddEventInSchedule([FromRoute]Guid id, [FromBody]AddEventToScheduleDto dto)
        {
            await _service.AddEventInSchedule(dto.EventId, id);
            return Ok();
        }
    }
}
