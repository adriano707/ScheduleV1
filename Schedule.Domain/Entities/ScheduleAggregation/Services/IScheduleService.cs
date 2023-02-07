using Schedule.Domain.Entities.UserAggregation;

namespace Schedule.Domain.Entities.ScheduleAggregation.Services
{
    public interface IScheduleService
    {
        Task<Schedule> CreateSchedule(string name, string description);
        Task DeleteSchedule(Guid id);
        Task<Schedule> UpdateSchedule(Guid id, string name, string description);
        Task<Schedule> GetScheduleById(Guid id);
        List<Schedule> GetAllSchedule();
        Task AddEventInSchedule(Guid eventId, Guid scheduleId);
    }
}
