using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParentsAbroad.Models.Models;


namespace ParentsAbroad.Models.DataContext.Configurations
{
    public class ChildConfig : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder) 
        {
            builder.ToTable("Children");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasOne(f => f.Family)
                .WithMany(c => c.Children)
                .HasForeignKey(x => x.FamilyId);
        }
    }
}
