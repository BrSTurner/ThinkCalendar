using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Think.Calendar.Domain.Model;

namespace Think.Calendar.Infrastructure.EntityMapping
{
    public class CalendarEventMapping : IEntityTypeConfiguration<CalendarEvent>
    {
        public void Configure(EntityTypeBuilder<CalendarEvent> builder)
        {
            builder.ToTable(nameof(CalendarEvent));

            builder.HasKey(e => e.Id);
            
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Email);
        }
    }
}
