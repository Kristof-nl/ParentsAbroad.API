﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParentsAbroad.Models.DataContext;

#nullable disable

namespace ParentsAbroad.Models.Migrations
{
    [DbContext(typeof(ParentsAbroadDbContext))]
    partial class ParentsAbroadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParentsAbroad.Models.Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Children", (string)null);
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.ChildLanguage", b =>
                {
                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("ChildId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("ChildLanguages");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Families", (string)null);
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Languages", (string)null);
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Parents", (string)null);
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.ParentLanguage", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("ParentId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("ParentLanguages");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Child", b =>
                {
                    b.HasOne("ParentsAbroad.Models.Models.Family", "Family")
                        .WithMany("Children")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.ChildLanguage", b =>
                {
                    b.HasOne("ParentsAbroad.Models.Models.Child", "Child")
                        .WithMany("Languages")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParentsAbroad.Models.Models.Language", "Language")
                        .WithMany("Children")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Parent", b =>
                {
                    b.HasOne("ParentsAbroad.Models.Models.Family", "Family")
                        .WithMany("Parents")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.ParentLanguage", b =>
                {
                    b.HasOne("ParentsAbroad.Models.Models.Language", "Language")
                        .WithMany("Parents")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParentsAbroad.Models.Models.Parent", "Parent")
                        .WithMany("Languages")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Child", b =>
                {
                    b.Navigation("Languages");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Family", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Parents");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Language", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Parents");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Parent", b =>
                {
                    b.Navigation("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}
