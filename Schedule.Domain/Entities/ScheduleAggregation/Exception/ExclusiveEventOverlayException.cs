namespace Schedule.Domain.Entities.ScheduleAggregation.Exception
{
    public class ExclusiveEventOverlayException : System.Exception
    {
        public ExclusiveEventOverlayException() : base("Não é possível sobrepor um evento exclusivo."){}
    }
}
