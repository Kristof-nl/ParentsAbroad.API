using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Models.DataContext.Configurations
{
    public class LikeToDoConfig : IEntityTypeConfiguration<LikeToDo>
    {
        public void Configure(EntityTypeBuilder<LikeToDo> builder)
        {
            builder.ToTable("LikeToDoThings");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
