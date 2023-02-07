namespace Schedule.Domain.Entities.UserAggregation
{
    public class User
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        private List<ScheduleAggregation.Schedule> _schedules;
        public IReadOnlyCollection<ScheduleAggregation.Schedule> Schedules => _schedules;

        public User() { }

        public User(string name, string email)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Email = email;
        }
    }
}
