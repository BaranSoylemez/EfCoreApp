﻿// <auto-generated />
using System;
using EfCoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("EfCoreApp.Data.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EfCoreApp.Data.CourseRegister", b =>
                {
                    b.Property<int>("RegId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RegId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseRegisters");
                });

            modelBuilder.Entity("EfCoreApp.Data.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Studentname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Studentsurname")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EfCoreApp.Data.Trainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrainerEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrainerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrainerPhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrainerSurname")
                        .HasColumnType("TEXT");

                    b.HasKey("TrainerId");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("EfCoreApp.Data.Course", b =>
                {
                    b.HasOne("EfCoreApp.Data.Trainer", "Trainer")
                        .WithMany("Courses")
                        .HasForeignKey("TrainerId");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("EfCoreApp.Data.CourseRegister", b =>
                {
                    b.HasOne("EfCoreApp.Data.Course", "Course")
                        .WithMany("CourseRegisters")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreApp.Data.Student", "Student")
                        .WithMany("CourseRegisters")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EfCoreApp.Data.Course", b =>
                {
                    b.Navigation("CourseRegisters");
                });

            modelBuilder.Entity("EfCoreApp.Data.Student", b =>
                {
                    b.Navigation("CourseRegisters");
                });

            modelBuilder.Entity("EfCoreApp.Data.Trainer", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}