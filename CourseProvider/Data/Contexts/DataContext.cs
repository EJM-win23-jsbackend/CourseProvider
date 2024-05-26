using CourseProvider.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProvider.Data.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<CourseEntity> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEntity>().ToContainer("Courses");
            modelBuilder.Entity<CourseEntity>().HasKey(c => c.Id);
            modelBuilder.Entity<CourseEntity>().HasPartitionKey(c => c.Id);

            //modelBuilder.Entity<CourseEntity>().Property(c => c.Id)
            //   .ValueGeneratedNever(); // not working

            modelBuilder.Entity<CourseEntity>().OwnsOne(c => c.Prices);
            modelBuilder.Entity<CourseEntity>().OwnsMany(c => c.Authors);
            modelBuilder.Entity<CourseEntity>().OwnsOne(c => c.Content, content => content.OwnsMany(c => c.ProgramDetails));
        }
    }
}

