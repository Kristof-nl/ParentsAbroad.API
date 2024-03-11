﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Models.DataContext.Configurations
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
            builder.HasOne(a => a.Family)
                .WithOne(f => f.Address)
                .HasForeignKey<Address>(x => x.FamilyId);

        }
    }
}
