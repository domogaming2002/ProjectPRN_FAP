using PRN221_Project_RazorPage.DataAccess.Data;
using PRN221_Project_WPF.DataAccess.Models;

namespace PRN221_Project_RazorPage.DataAccess.Manager
{
    public class SubjectManager
    {
        DataContext _context;
        public SubjectManager(DataContext context)
        { _context = context; }

        public List<Subject>? GetList()
        {
            return _context.Subjects.ToList();
        }

        public Subject? GetById(int subjectId)
        {
            return _context.Subjects.FirstOrDefault(s => s.SubjectId == subjectId);
        }

        public Boolean Create(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(Subject subject)
        {
            try
            {
                _context.Subjects.Remove(subject);
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

        public Boolean Update(Subject subject)
        {
            try
            {
                _context.Subjects.Update(subject);
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
