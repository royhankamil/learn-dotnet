using Microsoft.EntityFrameworkCore;

namespace FutsalBooking.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
        
        }

        public DbSet<Fields> Fields { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservations>().HasOne(u => u.user)
                .WithMany(p => p.reservations)
                .HasForeignKey(u => u.user_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservations>().HasOne(u => u.field)
                .WithMany(p => p.reservations)
                .HasForeignKey(u => u.field_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payments>().HasOne(u => u.reservation)
                .WithOne(p => p.payment)
                .HasForeignKey<Payments>(p => p.reservation_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
