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

            modelBuilder.Entity("ParentsAbroad.Models.Models.ChildLikeToDo", b =>
                {
                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("LikeToDoId")
                        .HasColumnType("int");

                    b.HasKey("ChildId", "LikeToDoId");

                    b.HasIndex("LikeToDoId");

                    b.ToTable("ChildLikeToDo");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.ChildSchoolSubject", b =>
                {
                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("SchoolSubjectId")
                        .HasColumnType("int");

                    b.HasKey("ChildId", "SchoolSubjectId");

                    b.HasIndex("SchoolSubjectId");

                    b.ToTable("ChildSchoolSubjects");
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

            modelBuilder.Entity("ParentsAbroad.Models.Models.LikeToDo", b =>
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

                    b.ToTable("LikeToDoThings", (string)null);
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

            modelBuilder.Entity("ParentsAbroad.Models.Models.SchoolSubject", b =>
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

                    b.ToTable("SchoolSubjects", (string)null);
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
                        .WithMany("ChildLanguages")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParentsAbroad.Models.Models.Language", "Language")
                        .WithMany("ChildLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.ChildLikeToDo", b =>
                {
                    b.HasOne("ParentsAbroad.Models.Models.Child", "Child")
                        .WithMany("ChildLikeToDoThings")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParentsAbroad.Models.Models.LikeToDo", "LikeToDo")
                        .WithMany("ChildLikeToDoThings")
                        .HasForeignKey("LikeToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("LikeToDo");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.ChildSchoolSubject", b =>
                {
                    b.HasOne("ParentsAbroad.Models.Models.Child", "Child")
                        .WithMany("ChildSchoolSubjects")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParentsAbroad.Models.Models.SchoolSubject", "SchoolSubject")
                        .WithMany("ChildSchoolSubjects")
                        .HasForeignKey("SchoolSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("SchoolSubject");
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
                        .WithMany("ParentLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParentsAbroad.Models.Models.Parent", "Parent")
                        .WithMany("ParentLanguages")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Child", b =>
                {
                    b.Navigation("ChildLanguages");

                    b.Navigation("ChildLikeToDoThings");

                    b.Navigation("ChildSchoolSubjects");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Family", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Parents");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Language", b =>
                {
                    b.Navigation("ChildLanguages");

                    b.Navigation("ParentLanguages");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.LikeToDo", b =>
                {
                    b.Navigation("ChildLikeToDoThings");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.Parent", b =>
                {
                    b.Navigation("ParentLanguages");
                });

            modelBuilder.Entity("ParentsAbroad.Models.Models.SchoolSubject", b =>
                {
                    b.Navigation("ChildSchoolSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
