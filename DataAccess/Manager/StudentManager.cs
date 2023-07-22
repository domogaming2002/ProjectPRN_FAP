using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class StudentManager 
    {
        DataContext _context;
        public StudentManager(DataContext context)
        { _context = context; }

        public List<Student>? GetList()
        {
            return _context.Students.Where(t => t.IsDelete == false).ToList();
        }

        public Student? GetById(int studentId)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId == studentId && s.IsDelete == false);
        }

        public Boolean Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(Student student)
        {
            try
            {
                Student studentDelete = GetById(student.StudentId);
                studentDelete.IsDelete = true;
                _context.Students.Remove(studentDelete);
                _context.SaveChanges();
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean Update(Student student)
        {
            try
            {
                Student studentUpdate = GetById(student.StudentId);
                studentUpdate.StudentCode = student.StudentCode;
                _context.Students.Update(studentUpdate);
                _context.SaveChanges();
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
