using esemkarailways.Models;
using Microsoft.EntityFrameworkCore;

namespace esemkarailways.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        { 
        }

        public DbSet<Passenger> passenger { get; set; }
        public DbSet<Schedule> schedule { get; set; }
        public DbSet<Station> station { get; set; }
        public DbSet<Ticket> ticket { get; set; }
        public DbSet<Train> train { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasOne(u => u.Passenger)
                .WithMany(p => p.Tickets)
                .HasForeignKey(u => u.PassengerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>().HasOne(u => u.Schedule)
                .WithMany(p => p.Tickets)
                .HasForeignKey(u => u.ScheduleID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Schedule>().HasOne(u => u.Train)
                .WithMany(p => p.Schedules)
                .HasForeignKey(u => u.TrainID);

            modelBuilder.Entity<Schedule>().HasOne(u=>u.ArrivalStation)
                .WithMany(p => p.ArrivalSchedules)
                .HasForeignKey(u => u.ArrivalStationID);
            
            modelBuilder.Entity<Schedule>().HasOne(u=>u.DepartureStation)
                .WithMany(p => p.DepartureSchedules)
                .HasForeignKey(u => u.DepartureStationID);

            
        }
    }
}
