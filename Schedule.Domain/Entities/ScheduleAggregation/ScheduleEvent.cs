namespace Schedule.Domain.Entities.ScheduleAggregation
{
    public class ScheduleEvent
    {
        public Schedule Schedule { get; private set; }
        public Guid ScheduleId { get; private set; }
        public Event Event { get; private set; }
        public Guid EventId { get; private set; }
        public bool IsOwner { get; private set; }

        public ScheduleEvent() { }
        public ScheduleEvent(Schedule schedule, Event @event, bool isOwner = false)
        {
            Schedule = schedule;
            Event = @event;
            IsOwner = isOwner;
        }
    }
}
