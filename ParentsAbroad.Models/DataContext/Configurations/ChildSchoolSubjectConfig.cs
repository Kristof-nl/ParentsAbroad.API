using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Models.DataContext.Configurations
{
    public class ChildSchoolSubjectConfig : IEntityTypeConfiguration<ChildSchoolSubject>
    {
        public void Configure(EntityTypeBuilder<ChildSchoolSubject> builder)
        {
            builder.HasKey(css => new { css.ChildId, css.SchoolSubjectId });
            builder.HasOne(css => css.Child)
                .WithMany(css => css.ChildSchoolSubjects)
                .HasForeignKey(css => css.ChildId);
            builder.HasOne(css => css.SchoolSubject)
               .WithMany(css => css.ChildSchoolSubjects)
               .HasForeignKey(cl => cl.SchoolSubjectId);
        }
    }
}
