using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.Models;
using ProjectPRN_FAP.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class TeacherManager
    {
        DataContext _context;
        public TeacherManager(DataContext context)
        { _context = context; }

        public List<Teacher>? GetList()
        {
            return _context.Teachers.Include(s => s.User).Where(t => t.IsDelete == false).ToList();
        }

        public Teacher? GetById(int teacherId)
        {
            return _context.Teachers.FirstOrDefault(s => s.TeacherId == teacherId && s.IsDelete == false);
        }

        public Boolean Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(Teacher teacher)
        {
            try
            {
                Teacher teacherDelete = GetById(teacher.TeacherId);
                teacherDelete.IsDelete = true;
                _context.Teachers.Remove(teacherDelete);
                _context.SaveChanges();
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean Update(Teacher teacher)
        {
            try
            {
                Teacher teacherUpdate = GetById(teacher.TeacherId);
                teacherUpdate.TeacherCode = teacher.TeacherCode;
                _context.Teachers.Update(teacherUpdate);
                _context.SaveChanges();
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}

