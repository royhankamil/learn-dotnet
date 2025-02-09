using Microsoft.EntityFrameworkCore;

namespace TestApi.Models
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Users> users { get; set; }
        public DbSet<Books> books { get; set; }
        public DbSet<Comment> comment { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>().HasOne(b => b.creator)
                .WithMany(u => u.Books)
                .HasForeignKey(u => u.creator_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>().HasOne(b => b.user)
                .WithMany(u => u.Comments)
                .HasForeignKey(u => u.user_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>().HasOne(b => b.book)
                .WithMany(b => b.comments)
                .HasForeignKey(u => u.book_id)
                .OnDelete(DeleteBehavior.Cascade);

        }


    }
}
