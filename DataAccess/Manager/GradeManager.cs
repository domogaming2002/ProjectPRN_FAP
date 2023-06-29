using PRN221_Project_RazorPage.DataAccess.Data;
using PRN221_Project_WPF.DataAccess.Models;

namespace PRN221_Project_RazorPage.DataAccess.Manager
{
    public class GradeManager
    {
        DataContext _context;
        public GradeManager(DataContext context)
        { _context = context; }

        public List<Grade>? GetList()
        {
            return _context.Grades.ToList();
        }

        public Grade? GetById(int gradeId)
        {
            return _context.Grades.FirstOrDefault(s => s.GradeID == gradeId);
        }

        public Boolean Create(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(Grade grade)
        {
            try
            {
                _context.Grades.Remove(grade);
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

        public Boolean Update(Grade grade)
        {
            try
            {
                _context.Grades.Update(grade);
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
