using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class ClassManager
    {
        DataContext _context;
        public ClassManager(DataContext context)
        { _context = context; }

        public List<Class>? GetList()
        {
            return _context.Classes.Where(s => s.IsDelete == false).ToList();
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
                Class? clase = GetById(classe.ClassId);
                clase.IsDelete = true;
                _context.Classes.Update(clase);
                _context.SaveChanges();
                    return true;
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
                Class? classe1 = GetById(classe.ClassId);
                classe1.ClassName = classe.ClassName;
                _context.Classes.Update(classe1);
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
