﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OmniGLM_API.db;

#nullable disable

namespace GoalFundApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GoalFundApi.Models.Goal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Completed")
                        .HasColumnType("boolean")
                        .HasColumnName("completed");

                    b.Property<DateOnly>("CompletedAt")
                        .HasColumnType("date")
                        .HasColumnName("completed_at");

                    b.Property<int>("Cost")
                        .HasColumnType("integer")
                        .HasColumnName("cost");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_goals");

                    b.ToTable("goals", (string)null);
                });

            modelBuilder.Entity("GoalFundApi.Models.Quest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Completed")
                        .HasColumnType("boolean")
                        .HasColumnName("completed");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer")
                        .HasColumnName("frequency");

                    b.Property<int>("Reward")
                        .HasColumnType("integer")
                        .HasColumnName("reward");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("task_name");

                    b.HasKey("Id")
                        .HasName("pk_quests");

                    b.ToTable("quests", (string)null);
                });

            modelBuilder.Entity("GoalFundApi.Models.Requirement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Completed")
                        .HasColumnType("boolean")
                        .HasColumnName("completed");

                    b.Property<Guid>("GoalId")
                        .HasColumnType("uuid")
                        .HasColumnName("goal_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_requirements");

                    b.HasIndex("GoalId")
                        .HasDatabaseName("ix_requirements_goal_id");

                    b.ToTable("requirements", (string)null);
                });

            modelBuilder.Entity("GoalFundApi.Models.Requirement", b =>
                {
                    b.HasOne("GoalFundApi.Models.Goal", null)
                        .WithMany("Requirements")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_requirements_goals_goal_id");
                });

            modelBuilder.Entity("GoalFundApi.Models.Goal", b =>
                {
                    b.Navigation("Requirements");
                });
#pragma warning restore 612, 618
        }
    }
}
