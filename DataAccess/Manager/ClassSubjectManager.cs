using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class ClassSubjectManager
    {
        DataContext _context;
        public ClassSubjectManager(DataContext context)
        { _context = context; }

        public List<ClassSubject>? GetList()
        {
            return _context.ClassSubjects.ToList();
        }

        public ClassSubject? GetById(int classSubjectId)
        {
            return _context.ClassSubjects.FirstOrDefault(s => s.ClassSubjectId == classSubjectId);
        }
        public List<ClassSubject>? GetListBySemester(int semesterId)
        {
            return _context.ClassSubjects.Where(cs => cs.SemesterId == semesterId).ToList();
        }

        public Boolean Create(ClassSubject classSubject)
        {
            _context.ClassSubjects.Add(classSubject);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(ClassSubject classSubject)
        {
            try
            {
                _context.ClassSubjects.Remove(classSubject);
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

        public Boolean Update(ClassSubject classSubject)
        {
            try
            {
                _context.ClassSubjects.Update(classSubject);
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

