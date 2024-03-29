﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Models.DataContext.Configurations
{
    public class ChildLanguageConfig : IEntityTypeConfiguration<ChildLanguage>
    {
        public void Configure(EntityTypeBuilder<ChildLanguage> builder)
        {
            builder.HasKey(cl => new { cl.ChildId, cl.LanguageId });
            builder.HasOne(cl => cl.Child)
                .WithMany(cl => cl.ChildLanguages)
                .HasForeignKey(cl => cl.ChildId);
            builder.HasOne(cl => cl.Language)
               .WithMany(cl => cl.ChildLanguages)
               .HasForeignKey(cl => cl.LanguageId);
        }
    }
}
