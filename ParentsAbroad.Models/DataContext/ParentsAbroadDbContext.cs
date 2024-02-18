using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Models.DataContext.Configurations;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Models.DataContext
{
    public class ParentsAbroadDbContext :DbContext
    {
        public ParentsAbroadDbContext(DbContextOptions<ParentsAbroadDbContext> options) : base(options) 
        {
            
        }

        DbSet<Family> Families { get; set; }
        DbSet<Parent> Children { get; set; }
        DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChildConfig());
            modelBuilder.ApplyConfiguration(new ParentConfig());
        }

    }
}
