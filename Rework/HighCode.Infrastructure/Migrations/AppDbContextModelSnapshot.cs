﻿// <auto-generated />
using System;
using HighCode.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HighCode.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CodeTaskCollectionOfTasks", b =>
                {
                    b.Property<Guid>("CollectionsOfTasksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TasksId")
                        .HasColumnType("uuid");

                    b.HasKey("CollectionsOfTasksId", "TasksId");

                    b.HasIndex("TasksId");

                    b.ToTable("CodeTaskCollectionOfTasks");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CodeTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("CodeTemplate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Complexity")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSuggested")
                        .HasColumnType("boolean");

                    b.Property<string>("ProgrammingLanguage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UnitTestCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("CodeTasks");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CodeTaskSolution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FirstPublishDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsTested")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RelatedTaskId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RelatedTaskId");

                    b.ToTable("CodeTaskSolutions");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CodeTaskSolutionReactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<int>("Reaction")
                        .HasColumnType("integer");

                    b.Property<Guid>("SolutionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SolutionId");

                    b.ToTable("CodeTaskSolutionReactions");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CollectionOfTasks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("CollectionOfTasks");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AnotherAuthor")
                        .HasColumnType("text");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CodeTaskSolutionId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RelatedTargetId")
                        .HasColumnType("uuid");

                    b.Property<int>("TargetType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CodeTaskSolutionId");

                    b.HasIndex("CommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CommentsReactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Reaction")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentsReactions");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.Leaderboard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Score")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Leaderboard");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.StoreValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StoreValues");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CodeTaskCollectionOfTasks", b =>
                {
                    b.HasOne("HighCode.Infrastructure.Entities.CollectionOfTasks", null)
                        .WithMany()
                        .HasForeignKey("CollectionsOfTasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HighCode.Infrastructure.Entities.CodeTask", null)
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CodeTask", b =>
                {
                    b.HasOne("HighCode.Infrastructure.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CodeTaskSolution", b =>
                {
                    b.HasOne("HighCode.Infrastructure.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HighCode.Infrastructure.Entities.CodeTask", "RelatedTask")
                        .WithMany()
                        .HasForeignKey("RelatedTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("RelatedTask");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CodeTaskSolutionReactions", b =>
                {
                    b.HasOne("HighCode.Infrastructure.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HighCode.Infrastructure.Entities.CodeTaskSolution", "Solution")
                        .WithMany()
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CollectionOfTasks", b =>
                {
                    b.HasOne("HighCode.Infrastructure.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.Comment", b =>
                {
                    b.HasOne("HighCode.Infrastructure.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HighCode.Infrastructure.Entities.CodeTaskSolution", null)
                        .WithMany("Comments")
                        .HasForeignKey("CodeTaskSolutionId");

                    b.HasOne("HighCode.Infrastructure.Entities.Comment", null)
                        .WithMany("Replies")
                        .HasForeignKey("CommentId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CommentsReactions", b =>
                {
                    b.HasOne("HighCode.Infrastructure.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HighCode.Infrastructure.Entities.Comment", "Comment")
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.Leaderboard", b =>
                {
                    b.HasOne("HighCode.Infrastructure.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.CodeTaskSolution", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("HighCode.Infrastructure.Entities.Comment", b =>
                {
                    b.Navigation("Reactions");

                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}
