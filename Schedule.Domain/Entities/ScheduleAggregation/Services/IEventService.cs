using Schedule.Domain.Entities.ScheduleAggregation.Enums;

namespace Schedule.Domain.Entities.ScheduleAggregation.Services
{
    public interface IEventService
    {
        Task DeleteEvent(Guid id);
        Task<Event> GetEventById(Guid id);
        Task<List<Event>> GetAllEvent();
        Task<Event> UpdateEvent(Guid id, string name, string description, DateTimeOffset date, string locality, int participants, EventType eventType);
        Task<Event> CreateEvent(string name, string description, DateTimeOffset date, string locality, int participants, EventType eventType, Guid scheduleId);
        Task<bool> ActivateEvent(Guid eventId);
    }
}
