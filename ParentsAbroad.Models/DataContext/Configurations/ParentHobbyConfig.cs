using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Models.DataContext.Configurations
{
    public class ParentHobbyConfig : IEntityTypeConfiguration<ParentHobby>
    {
        public void Configure(EntityTypeBuilder<ParentHobby> builder)
        {
            builder.HasKey(pl => new { pl.ParentId, pl.HobbyId });
            builder.HasOne(pl => pl.Parent)
                .WithMany(pl => pl.ParentHobbys)
                .HasForeignKey(pl => pl.ParentId);
            builder.HasOne(pl => pl.Hobby)
               .WithMany(pl => pl.ParentHobbys)
               .HasForeignKey(pl => pl.HobbyId);
        }
    }
}
