using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Domain.Entities.ScheduleAggregation;

namespace Schedule.Data.Configuration
{
    public class EventCopnfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnType("varchar(100)");
            builder.Property(e => e.Description).HasColumnType("varchar(500)");
        }
    }
}
