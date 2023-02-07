using Schedule.Domain.Entities.ScheduleAggregation;
using Schedule.Domain.Entities.ScheduleAggregation.Enums;

namespace Schedule.API.V1.Dtos
{
    public class CreateEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Locality { get; set; }
        public int Participants { get; set; }
        public EventType EventType { get; set; }
    }
}
