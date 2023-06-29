using PRN221_Project_RazorPage.DataAccess.Data;
using PRN221_Project_RazorPage.DataAccess.Models;
using PRN221_Project_WPF.DataAccess.Models;

namespace PRN221_Project_RazorPage.DataAccess.Manager
{
    public class SemesterManager
    {
        DataContext _context;
        public SemesterManager(DataContext context)
        { _context = context; }

        public List<Semester>? GetList()
        {
            return _context.Semesters.ToList();
        }

        public Semester? GetById(int semesterId)
        {
            return _context.Semesters.FirstOrDefault(s => s.SemesterId == semesterId);
        }

        public Boolean Create(Semester semester)
        {
            _context.Semesters.Add(semester);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(Semester semester)
        {
            try
            {
                _context.Semesters.Remove(semester);
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

        public Boolean Update(Semester semester)
        {
            try
            {
                _context.Semesters.Update(semester);
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
