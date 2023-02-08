using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Domain.Entities.ScheduleAggregation;

namespace Schedule.Data.Configuration
{
    public class ScheduleEventConfiguration : IEntityTypeConfiguration<ScheduleEvent>
    {
        public void Configure(EntityTypeBuilder<ScheduleEvent> builder)
        {
            builder.HasKey(s => new { s.ScheduleId, s.EventId });

            builder.HasOne(e => e.Event).WithMany(e => e.ScheduleEvents).HasForeignKey(s => s.EventId);
            builder.HasOne(s => s.Schedule).WithMany(e => e.ScheduleEvents).HasForeignKey(s => s.ScheduleId);
        }
    }
}
