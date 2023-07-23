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
            return _context.ClassSubjects.Where(c => c.IsDelete == false).ToList();
        }

        public ClassSubject? GetById(int classSubjectId)
        {
            return _context.ClassSubjects.FirstOrDefault(s => s.ClassSubjectId == classSubjectId);
        }
        public List<ClassSubject>? GetListBySemester(int semesterId)
        {
            return _context.ClassSubjects.Where(cs => cs.SemesterId == semesterId && cs.IsDelete == false).ToList();
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
                ClassSubject cs = GetById(classSubject.ClassSubjectId);
                cs.IsDelete = true;
                _context.ClassSubjects.Update(cs);
                _context.SaveChanges();
                    return true;
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
                ClassSubject cs = GetById(classSubject.ClassSubjectId);
                cs.SubjectId = classSubject.SubjectId;
                cs.SemesterId = classSubject.SemesterId;
                cs.TeacherId = classSubject.TeacherId;
                cs.ClassId = classSubject.ClassId;
                _context.ClassSubjects.Update(cs);
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

