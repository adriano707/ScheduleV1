using Schedule.Domain.Entities.UserAggregation;
using Schedule.Domain.Repositories;

namespace Schedule.Domain.Entities.ScheduleAggregation.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUserIdentity _userIdentity;
        private readonly IRepository _repository;

        public ScheduleService(IRepository repository, IUserIdentity userIdentity)
        {
            _repository = repository;
            _userIdentity = userIdentity;
        }

        public async Task<Schedule> CreateSchedule(string name, string description)
        {
            var user = _repository.Query<User>().FirstOrDefault(u => u.UserName == _userIdentity.UserName);

            Schedule schedule = new Schedule(user, name, description);

            await _repository.InsertAsync(schedule);
            await _repository.SaveChangeAsync();

            return schedule;
        }

        public async Task DeleteSchedule(Guid id)
        {
            var schedule = _repository.Query<Schedule>().FirstOrDefault(s => s.Id == id);

            if (schedule != null)
            {
                _repository.Delete(schedule);
                await _repository.SaveChangeAsync();
            }
        }

        public async Task<Schedule> UpdateSchedule(Guid id, string name, string description)
        {
            var schedule = _repository.Query<Schedule>().FirstOrDefault(s => s.Id == id);

            if (schedule is not null)
            {
                schedule.UpdateSchedule(name, description);
                _repository.Update(schedule);
                await _repository.SaveChangeAsync();

                return schedule;
            }

            return null;
        }

        public async Task<Schedule> GetScheduleById(Guid id)
        {
            var schedule = _repository.Query<Schedule>().FirstOrDefault(s => s.Id == id);
            return schedule;
        }

        public List<Schedule> GetAllSchedule()
        {
            return _repository.Query<Schedule>().ToList();
        }

        public async Task AddEventInSchedule(Guid eventId, Guid scheduleId)
        {
            var @event = _repository.Query<Event>().FirstOrDefault(e => e.Id == eventId);
            var schedule = _repository.Query<Schedule>().FirstOrDefault(s => s.Id == scheduleId);

            if (@event is not null && schedule is not null)
            {
                schedule.AddEvent(@event);
                _repository.Update(schedule);
                await _repository.SaveChangeAsync();
            }
        }
    }
}
