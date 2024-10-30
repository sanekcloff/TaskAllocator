﻿// <auto-generated />
using System;
using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations.SqliteDB
{
    [DbContext(typeof(SqliteDBContext))]
    partial class SqliteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Data.Models.Objective", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Objectives");
                });

            modelBuilder.Entity("Data.Models.ObjectiveExecutor", b =>
                {
                    b.Property<Guid>("ObjectiveId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ExecutorId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReady")
                        .HasColumnType("INTEGER");

                    b.HasKey("ObjectiveId", "ExecutorId");

                    b.HasIndex("ExecutorId");

                    b.ToTable("ObjectiveExecutors");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("BLOB");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Middlename")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Models.Objective", b =>
                {
                    b.HasOne("Data.Models.User", "Creator")
                        .WithMany("CreatedObjectives")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Data.Models.ObjectiveExecutor", b =>
                {
                    b.HasOne("Data.Models.User", "Executor")
                        .WithMany("ExecutingObjectives")
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Objective", "Objective")
                        .WithMany("Executors")
                        .HasForeignKey("ObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Executor");

                    b.Navigation("Objective");
                });

            modelBuilder.Entity("Data.Models.Objective", b =>
                {
                    b.Navigation("Executors");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Navigation("CreatedObjectives");

                    b.Navigation("ExecutingObjectives");
                });
#pragma warning restore 612, 618
        }
    }
}