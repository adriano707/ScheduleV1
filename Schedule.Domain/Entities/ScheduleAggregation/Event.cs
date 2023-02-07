using Schedule.Domain.Entities.ScheduleAggregation.Enums;

namespace Schedule.Domain.Entities.ScheduleAggregation
{
    public class Event
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public string Locality { get; private set; }
        public int Participants { get; private set; }
        public EventType EventType { get; private set; }
        public EventStatus Status { get; private set; }
        public bool IsActive { get; private set; }
        private List<ScheduleEvent> _scheduleEvents;
        public IReadOnlyCollection<ScheduleEvent> Events => _scheduleEvents;

        public Event(string name, string description, DateTimeOffset date, string locality, int participants, EventType eventType)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Date = date;
            Locality = locality ?? throw new ArgumentNullException(nameof(locality));
            Participants = participants;
            EventType = eventType;
            IsActive = false;
            Status = EventStatus.Opened;
        }

        public void UpdateEvent(string name, string description, DateTimeOffset date, string locality, int participants, EventType eventType)
        {
            Name = name;
            Description = description;
            Date = date;
            Locality = locality;
            Participants = participants;
            EventType = eventType;
        }

        public void ActiveEvent()
        {
            IsActive = true;
        }
    }
}
