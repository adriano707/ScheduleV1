using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schedule.Data.Configuration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Domain.Entities.ScheduleAggregation.Schedule>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ScheduleAggregation.Schedule> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(u => u.User).WithMany(u => u.Schedules);
            builder.Property(s => s.UserId).HasColumnType("nvarchar(450)");

            builder.HasMany(e => e.Events)
                .WithOne(s => s.Schedule).HasForeignKey(e => e.ScheduleId);
        }
    }
}
