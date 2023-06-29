using PRN221_Project_RazorPage.DataAccess.Data;
using PRN221_Project_RazorPage.DataAccess.Models;
using PRN221_Project_WPF.DataAccess.Models;

namespace PRN221_Project_RazorPage.DataAccess.Manager
{
    public class ClassManager
    {
        DataContext _context;
        public ClassManager(DataContext context)
        { _context = context; }

        public List<Class>? GetList()
        {
            return _context.Classes.ToList();
        }

        public Class? GetById(int classId)
        {
            return _context.Classes.FirstOrDefault(s => s.ClassId == classId);
        }

        public Boolean Create(Class classe)
        {
            _context.Classes.Add(classe);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(Class classe)
        {
            try
            {
                _context.Classes.Remove(classe);
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

        public Boolean Update(Class classe)
        {
            try
            {
                _context.Classes.Update(classe);
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
