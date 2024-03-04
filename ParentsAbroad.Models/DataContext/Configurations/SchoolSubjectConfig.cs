using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Models.DataContext.Configurations
{
    public class SchoolSubjectConfig : IEntityTypeConfiguration<SchoolSubject>
    {
        public void Configure(EntityTypeBuilder<SchoolSubject> builder)
        {
            builder.ToTable("SchoolSubjects");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
