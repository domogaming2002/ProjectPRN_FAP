using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class SubjectManager
    {
        DataContext _context;
        public SubjectManager(DataContext context)
        { _context = context; }

        public List<Subject>? GetList()
        {
            return _context.Subjects.Where(s => s.IsDelete == false).ToList();
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
                Subject subject2 = GetById(subject.SubjectId);
                subject2.IsDelete = true;
                _context.Subjects.Update(subject2);
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
                Subject? subject1 = GetById(subject.SubjectId);
                subject1.SubjectSubName = subject.SubjectSubName;
                subject1.SubjectName = subject.SubjectName;
                _context.Subjects.Update(subject1);
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
