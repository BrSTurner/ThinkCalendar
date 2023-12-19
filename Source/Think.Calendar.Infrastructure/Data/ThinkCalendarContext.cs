using Microsoft.EntityFrameworkCore;
using Think.Calendar.Domain.Model;
using Think.Calendar.Infrastructure.EntityMapping;

namespace Think.Calendar.Infrastructure.Data
{
    public class ThinkCalendarContext : DbContext
    {
        public ThinkCalendarContext() { }

        public ThinkCalendarContext(DbContextOptions options) : base(options) { }

        public DbSet<CalendarEvent> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarEventMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
