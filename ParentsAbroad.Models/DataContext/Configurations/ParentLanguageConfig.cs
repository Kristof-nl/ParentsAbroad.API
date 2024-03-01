using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Models.DataContext.Configurations
{
    public class ParentLanguageConfig : IEntityTypeConfiguration<ParentLanguage>
    {
        public void Configure(EntityTypeBuilder<ParentLanguage> builder)
        {
            builder.HasKey(pl => new { pl.ParentId, pl.LanguageId });
            builder.HasOne(pl => pl.Parent)
                .WithMany(pl => pl.ParentLanguages)
                .HasForeignKey(pl => pl.ParentId);
            builder.HasOne(pl => pl.Language)
               .WithMany(pl => pl.Parents)
               .HasForeignKey(pl => pl.LanguageId);
        }
    }
}
