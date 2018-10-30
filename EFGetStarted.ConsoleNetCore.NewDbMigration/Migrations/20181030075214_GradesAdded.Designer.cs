﻿// <auto-generated />
using EFGetStarted.ConsoleNetCore.NewDbMigration.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFGetStarted.ConsoleNetCore.NewDbMigration.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20181030075214_GradesAdded")]
    partial class GradesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradeName");

                    b.Property<string>("Section");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradeId");

                    b.Property<string>("StudentName");

                    b.HasKey("StudentId");

                    b.HasIndex("GradeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.StudentAddress", b =>
                {
                    b.Property<int>("StudentAddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("AddressOfStudentId");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.HasKey("StudentAddressId");

                    b.HasIndex("AddressOfStudentId")
                        .IsUnique();

                    b.ToTable("StudentAddress");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.StudentCourse", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("CourseId");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradeId");

                    b.Property<string>("TeacherName");

                    b.Property<string>("TeacherType");

                    b.HasKey("TeacherID");

                    b.HasIndex("GradeId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Student", b =>
                {
                    b.HasOne("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.StudentAddress", b =>
                {
                    b.HasOne("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Student", "Student")
                        .WithOne("Address")
                        .HasForeignKey("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.StudentAddress", "AddressOfStudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.StudentCourse", b =>
                {
                    b.HasOne("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Teacher", b =>
                {
                    b.HasOne("EFGetStarted.ConsoleNetCore.NewDbMigration.Model.Grade", "Grade")
                        .WithMany("Teachers")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}