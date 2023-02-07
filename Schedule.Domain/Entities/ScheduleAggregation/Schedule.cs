using Schedule.Domain.Entities.UserAggregation;

namespace Schedule.Domain.Entities.ScheduleAggregation
{
    public class Schedule
    {
        private List<ScheduleEvent> _events;

        public Guid Id { get; private set; }
        public User User { get;  private set; }
        public string UserId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Schedule() { }
        public IReadOnlyCollection<ScheduleEvent> Events => _events;

        public Schedule(User user, string name, string description)
        {
            _events = new List<ScheduleEvent>();
            Id = Guid.NewGuid();
            User = user ?? throw new ArgumentNullException(nameof(user));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
        }

        public void AddEvent(Event @event, bool isOwner = false)
        {
            if (_events is null)
            {
                _events = new List<ScheduleEvent>();
            }

            _events.Add(new ScheduleEvent(this, @event));
        }

        public void UpdateSchedule(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
