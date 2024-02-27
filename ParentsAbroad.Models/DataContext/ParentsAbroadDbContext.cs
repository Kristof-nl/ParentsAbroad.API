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

        public DbSet<Family> Families { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ChildLanguage> ChildLanguages { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FamilyConfig());
            modelBuilder.ApplyConfiguration(new ChildConfig());
            modelBuilder.ApplyConfiguration(new ParentConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new ChildLanguageConfig());
        }

    }
}
