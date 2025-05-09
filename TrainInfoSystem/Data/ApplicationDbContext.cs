using Microsoft.EntityFrameworkCore;
using TrainInfoSystem.Models;

namespace TrainInfoSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Train> Trains { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Fare> Fares { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<PNR> PNRs { get; set; }
        public DbSet<TrainClass> TrainClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainClass>().HasKey(tc => new { tc.TrainId, tc.ClassId });
            modelBuilder.Entity<TrainClass>()
                .HasOne(tc => tc.Train)
                .WithMany(t => t.TrainClasses)
                .HasForeignKey(tc => tc.TrainId);
            modelBuilder.Entity<TrainClass>()
                .HasOne(tc => tc.Class)
                .WithMany()
                .HasForeignKey(tc => tc.ClassId);
        }
    }
}
