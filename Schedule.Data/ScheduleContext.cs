using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Schedule.Domain.Entities.ScheduleAggregation;
using Schedule.Domain.Entities.UserAggregation;

namespace Schedule.Data
{
    public class ScheduleContext : DbContext
    {
        public DbSet<Domain.Entities.ScheduleAggregation.Schedule> Schedule { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ScheduleEvent> ScheduleEvent { get; set; }
        public ScheduleContext()
        {
            
        }

        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
