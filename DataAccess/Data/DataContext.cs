using Microsoft.EntityFrameworkCore;
using PRN221_Project_RazorPage.DataAccess.Models;
using PRN221_Project_RazorPage.Models;
using PRN221_Project_WPF.DataAccess.Models;

namespace PRN221_Project_RazorPage.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<StudentClassSubject> StudentClassSubjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<SubjectGrade> SubjectGrades { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }
        public DbSet<DetailScore> DetailScores { get; set; }
        public DbSet<Semester> Semesters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                 .HasOne(s => s.User)
                 .WithMany(u => u.Students)
                 .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithMany(u => u.Teachers)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<ClassSubject>().HasKey(cs => new { cs.ClassSubjectId });

            modelBuilder.Entity<ClassSubject>()
                .HasOne(cs => cs.Class)
                .WithMany(C => C.classSubjects)
                .HasForeignKey(cs => cs.ClassId);

            modelBuilder.Entity<ClassSubject>()
                .HasOne(cs => cs.Subject)
                .WithMany(s => s.ClassSubjects)
                .HasForeignKey(cs => cs.SubjectId);

            modelBuilder.Entity<ClassSubject>()
                .HasOne(cs => cs.Teacher)
                .WithMany(t => t.ClassSubjects)
                .HasForeignKey(cs => cs.TeacherId);

            modelBuilder.Entity<ClassSubject>()
                .HasOne(cs => cs.Semester)
                .WithMany(t => t.ClassSubjects)
                .HasForeignKey(cs => cs.SemesterId);



            modelBuilder.Entity<SubjectGrade>().HasKey(sg => new { sg.SubjectId, sg.GradeId });

            modelBuilder.Entity<SubjectGrade>()
                .HasOne(sg => sg.Subject)
                .WithMany(s => s.SubjectGrades)
                .HasForeignKey(sg => sg.SubjectId);


            modelBuilder.Entity<SubjectGrade>()
                .HasOne(sg => sg.Grade)
                .WithMany(s => s.SubjectGrades)
                .HasForeignKey(sg => sg.GradeId);



            modelBuilder.Entity<Transcript>()
                .HasOne(t => t.Students)
                .WithMany(t => t.Transcripts)
                .HasForeignKey(t => t.StudentId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transcript>()
                .HasOne(t => t.Subject)
                .WithMany(s => s.Transcripts)
                .HasForeignKey(t => t.SubjectId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transcript>()
               .HasOne(t => t.ClassSubject)
               .WithMany(cs => cs.Transcripts)
               .HasForeignKey(t => t.ClassSubjectId);

            modelBuilder.Entity<StudentClassSubject>().HasKey(scs => new { scs.StudentClassSubjectId });

            modelBuilder.Entity<StudentClassSubject>()
              .HasOne(scs => scs.Student)
              .WithMany(s => s.StudentClassSubjects)
              .HasForeignKey(scs => scs.StudentId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentClassSubject>()
                .HasOne(scs => scs.ClassSubject)
                .WithMany(cs => cs.StudentClassSubjects)
                .HasForeignKey(scs => scs.ClasSubjectId).OnDelete(DeleteBehavior.NoAction);

            
        }

    }
}
