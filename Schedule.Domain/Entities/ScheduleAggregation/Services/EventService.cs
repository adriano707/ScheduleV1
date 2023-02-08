using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Entities.ScheduleAggregation.Enums;
using Schedule.Domain.Entities.ScheduleAggregation.Exception;
using Schedule.Domain.Repositories;

namespace Schedule.Domain.Entities.ScheduleAggregation.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository _repository;

        public EventService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Event> CreateEvent(string name, string description, DateTimeOffset date, string locality, int participants, EventType eventType, Guid scheduleId)
        {
            if (eventType == EventType.EXCLUSIVO && _repository.Query<Event>().Any(e => e.EventType == EventType.EXCLUSIVO && e.Date == date))
                throw new ExclusiveEventOverlayException();

            var schedule = _repository.Query<Schedule>()
                .Include(s => s.ScheduleEvents)
                .FirstOrDefault(s => s.Id == scheduleId);

            if (schedule is not null)
            {
                Event @event = new Event(name, description, date, locality, participants, eventType);
                await _repository.InsertAsync(@event);

                schedule.AddEvent(@event, true);
                _repository.Update(schedule);

                await _repository.SaveChangeAsync();

                return @event;
            }

            return null;
        }

        public async Task DeleteEvent(Guid id)
        {
            var @event = _repository.Query<Event>().FirstOrDefault(e => e.Id == id);

            if (@event != null)
            {
                _repository.Delete(@event);
                await _repository.SaveChangeAsync();
            }
        }

        public async Task<Event> GetEventById(Guid id)
        {
            var @event = _repository.Query<Event>().FirstOrDefault(e => e.Id == id);
            return @event;
        }

        public async Task<List<Event>> GetAllEvent()
        {
            var events = _repository.Query<Event>().ToList();
            return events;
        }

        public async Task<Event> UpdateEvent(Guid id, string name, string description, DateTimeOffset date, string locality, int participants,
            EventType eventType)
        {
            var @event = _repository.Query<Event>().FirstOrDefault(e => e.Id == id);

            @event.UpdateEvent(name, description, date, locality, participants, eventType);
            _repository.Update(@event);
            await _repository.SaveChangeAsync();

            return @event;
        }
    }
}
