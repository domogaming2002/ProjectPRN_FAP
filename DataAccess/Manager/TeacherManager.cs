using PRN221_Project_RazorPage.DataAccess.Data;
using PRN221_Project_RazorPage.Models;
using PRN221_Project_WPF.DataAccess.Models;

namespace PRN221_Project_RazorPage.DataAccess.Manager
{
    public class TeacherManager
    {
        DataContext _context;
        public TeacherManager(DataContext context)
        { _context = context; }

        public List<Teacher>? GetList()
        {
            return _context.Teachers.ToList();
        }

        public Teacher? GetById(int teacherId)
        {
            return _context.Teachers.FirstOrDefault(s => s.TeacherId == teacherId);
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
                _context.Teachers.Remove(teacher);
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

        public Boolean Update(Teacher teacher)
        {
            try
            {
                _context.Teachers.Update(teacher);
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

