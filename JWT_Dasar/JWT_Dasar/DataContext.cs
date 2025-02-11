using JWT_Dasar.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_Dasar
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(u => u.UserID);
            modelBuilder.Entity<Books>().HasKey(b => b.BookID);
        }
    }
}
