﻿// <auto-generated />
using System;
using HighCode.Presentation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HighCode.Presentation.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240411120058_CommentsUpdate")]
    partial class CommentsUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HighCode.Presentation.Data.Models.CodeTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CollectionOfTasksId")
                        .HasColumnType("int");

                    b.Property<int>("Complexity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammingLanguage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateFuncSignature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitTestCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CollectionOfTasksId");

                    b.HasIndex("UserDataId");

                    b.ToTable("CodeTasks");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.CodeTaskSolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTested")
                        .HasColumnType("bit");

                    b.Property<int>("RelatedTaskId")
                        .HasColumnType("int");

                    b.Property<int>("VotesDown")
                        .HasColumnType("int");

                    b.Property<int>("VotesUp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RelatedTaskId");

                    b.ToTable("CodeTaskSolutions");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.CollectionOfTasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Complexity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammingLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("CollectionOfTasks");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnotherAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedTaskId")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedTaskSolutionId")
                        .HasColumnType("int");

                    b.Property<int?>("RepliedCommentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RelatedTaskId");

                    b.HasIndex("RelatedTaskSolutionId");

                    b.HasIndex("RepliedCommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.UserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.UserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.UserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.UserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.CodeTask", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("HighCode.Presentation.Data.Models.CollectionOfTasks", null)
                        .WithMany("Tasks")
                        .HasForeignKey("CollectionOfTasksId");

                    b.HasOne("HighCode.Presentation.Data.Models.UserData", null)
                        .WithMany("SolvedTasks")
                        .HasForeignKey("UserDataId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.CodeTaskSolution", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HighCode.Presentation.Data.Models.CodeTask", "RelatedTask")
                        .WithMany()
                        .HasForeignKey("RelatedTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("RelatedTask");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.CollectionOfTasks", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.Comment", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("HighCode.Presentation.Data.Models.CodeTask", "RelatedTask")
                        .WithMany()
                        .HasForeignKey("RelatedTaskId");

                    b.HasOne("HighCode.Presentation.Data.Models.CodeTaskSolution", "RelatedTaskSolution")
                        .WithMany("Comments")
                        .HasForeignKey("RelatedTaskSolutionId");

                    b.HasOne("HighCode.Presentation.Data.Models.Comment", "RepliedComment")
                        .WithMany("Replies")
                        .HasForeignKey("RepliedCommentId");

                    b.Navigation("Author");

                    b.Navigation("RelatedTask");

                    b.Navigation("RelatedTaskSolution");

                    b.Navigation("RepliedComment");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.UserData", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.UserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.UserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.UserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.UserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.CodeTaskSolution", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.CollectionOfTasks", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.Comment", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("HighCode.Presentation.Data.Models.UserData", b =>
                {
                    b.Navigation("SolvedTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
