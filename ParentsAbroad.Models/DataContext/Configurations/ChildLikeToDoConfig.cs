using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParentsAbroad.Models.Models;
namespace ParentsAbroad.Models.DataContext.Configurations
{
    public class ChildLikeToDoConfig : IEntityTypeConfiguration<ChildLikeToDo>
    {
        public void Configure(EntityTypeBuilder<ChildLikeToDo> builder)
        {
            builder.HasKey(cl => new { cl.ChildId, cl.LikeToDoId });
            builder.HasOne(cl => cl.Child)
                .WithMany(cl => cl.ChildLikeToDoThings)
                .HasForeignKey(cl => cl.ChildId);
            builder.HasOne(cl => cl.LikeToDo)
               .WithMany(cl => cl.ChildLikeToDoThings)
               .HasForeignKey(cl => cl.LikeToDoId);
        }
    }
}
