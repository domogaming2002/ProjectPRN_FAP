﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectPRN_FAP.DataAccess.Data;

#nullable disable

namespace ProjectPRN_FAP.DataAccess.Data
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"), 1L, 1);

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.ClassSubject", b =>
                {
                    b.Property<int>("ClassSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassSubjectId"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("ClassSubjectId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassSubjects");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.DetailScore", b =>
                {
                    b.Property<int>("DetailScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailScoreId"), 1L, 1);

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<int>("TranscriptId")
                        .HasColumnType("int");

                    b.HasKey("DetailScoreId");

                    b.HasIndex("TranscriptId");

                    b.ToTable("DetailScores");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Grade", b =>
                {
                    b.Property<int>("GradeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeID"), 1L, 1);

                    b.Property<string>("GradeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<double>("Percent")
                        .HasColumnType("float");

                    b.HasKey("GradeID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Semester", b =>
                {
                    b.Property<int>("SemesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemesterId"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("SemesterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SemesterId");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectSubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.SubjectGrade", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("SubjectId", "GradeId");

                    b.HasIndex("GradeId");

                    b.ToTable("SubjectGrades");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Transcript", b =>
                {
                    b.Property<int>("TranscriptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TranscriptId"), 1L, 1);

                    b.Property<int>("ClassSubjectId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<double>("TotalScore")
                        .HasColumnType("float");

                    b.HasKey("TranscriptId");

                    b.HasIndex("ClassSubjectId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Transcripts");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Campus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectPRN_FAP.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("StudentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ProjectPRN_FAP.Models.StudentClassSubject", b =>
                {
                    b.Property<int>("StudentClassSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentClassSubjectId"), 1L, 1);

                    b.Property<int>("ClasSubjectId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("StudentClassSubjectId");

                    b.HasIndex("ClasSubjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentClassSubjects");
                });

            modelBuilder.Entity("ProjectPRN_FAP.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("TeacherCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.ClassSubject", b =>
                {
                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.Class", "Class")
                        .WithMany("classSubjects")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.Semester", "Semester")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.Subject", "Subject")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectPRN_FAP.Models.Teacher", "Teacher")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Semester");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.DetailScore", b =>
                {
                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.Transcript", "Transcript")
                        .WithMany("DetailScores")
                        .HasForeignKey("TranscriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transcript");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.SubjectGrade", b =>
                {
                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.Grade", "Grade")
                        .WithMany("SubjectGrades")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.Subject", "Subject")
                        .WithMany("SubjectGrades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Transcript", b =>
                {
                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.ClassSubject", "ClassSubject")
                        .WithMany("Transcripts")
                        .HasForeignKey("ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectPRN_FAP.Models.Student", "Students")
                        .WithMany("Transcripts")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.Subject", "Subject")
                        .WithMany("Transcripts")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ClassSubject");

                    b.Navigation("Students");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ProjectPRN_FAP.Models.Student", b =>
                {
                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.User", "User")
                        .WithMany("Students")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectPRN_FAP.Models.StudentClassSubject", b =>
                {
                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.ClassSubject", "ClassSubject")
                        .WithMany("StudentClassSubjects")
                        .HasForeignKey("ClasSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProjectPRN_FAP.Models.Student", "Student")
                        .WithMany("StudentClassSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ClassSubject");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjectPRN_FAP.Models.Teacher", b =>
                {
                    b.HasOne("ProjectPRN_FAP.DataAccess.Models.User", "User")
                        .WithMany("Teachers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Class", b =>
                {
                    b.Navigation("classSubjects");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.ClassSubject", b =>
                {
                    b.Navigation("StudentClassSubjects");

                    b.Navigation("Transcripts");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Grade", b =>
                {
                    b.Navigation("SubjectGrades");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Semester", b =>
                {
                    b.Navigation("ClassSubjects");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Subject", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("SubjectGrades");

                    b.Navigation("Transcripts");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.Transcript", b =>
                {
                    b.Navigation("DetailScores");
                });

            modelBuilder.Entity("ProjectPRN_FAP.DataAccess.Models.User", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("ProjectPRN_FAP.Models.Student", b =>
                {
                    b.Navigation("StudentClassSubjects");

                    b.Navigation("Transcripts");
                });

            modelBuilder.Entity("ProjectPRN_FAP.Models.Teacher", b =>
                {
                    b.Navigation("ClassSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
