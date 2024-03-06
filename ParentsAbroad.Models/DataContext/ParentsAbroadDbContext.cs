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
        public DbSet<ParentLanguage> ParentLanguages { get; set; }
        public DbSet<SchoolSubject> SchoolSubjects { get; set; }
        public DbSet<ChildSchoolSubject> ChildSchoolSubjects { get; set; }
        public DbSet<LikeToDo> LikeToDoThings { get; set; }
        public DbSet<ChildLikeToDo> ChildLikeToDo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FamilyConfig());
            modelBuilder.ApplyConfiguration(new ChildConfig());
            modelBuilder.ApplyConfiguration(new ParentConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new ChildLanguageConfig());
            modelBuilder.ApplyConfiguration(new ParentLanguageConfig());
            modelBuilder.ApplyConfiguration(new SchoolSubjectConfig());
            modelBuilder.ApplyConfiguration(new ChildSchoolSubjectConfig());
            modelBuilder.ApplyConfiguration(new LikeToDoConfig());
            modelBuilder.ApplyConfiguration(new ChildLikeToDoConfig());
        }

    }
}
