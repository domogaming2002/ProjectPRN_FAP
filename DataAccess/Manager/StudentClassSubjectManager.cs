using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class StudentClassSubjectManager
    {
        DataContext _context;
        public StudentClassSubjectManager(DataContext context)
        { _context = context; }

        public List<StudentClassSubject>? GetList()
        {
            return _context.StudentClassSubjects.Where(c => c.IsDelete == false).ToList();
        }

        public StudentClassSubject? GetById(int studentClassSubjectId)
        {
            return _context.StudentClassSubjects.FirstOrDefault(s => s.StudentClassSubjectId == studentClassSubjectId);
        }

        public StudentClassSubject? GetByStudentIdClassSubjectId(int studentId, int classSubjectId)
        {
            return _context.StudentClassSubjects.FirstOrDefault(s => s.StudentId == studentId && s.ClasSubjectId == classSubjectId);
        }
        public List<StudentClassSubject>? GetListByStudentId(int studentId)
        {
            return _context.StudentClassSubjects.Where(s => s.StudentId == studentId && s.IsDelete == false).ToList();
        }

        public List<StudentClassSubject>? GetListByClassSubjectId(int classSubjectId)
        {
            return _context.StudentClassSubjects.Where(s=> s.ClasSubjectId == classSubjectId && s.IsDelete == false).ToList();
        }

        public Boolean Create(StudentClassSubject studentClassSubject)
        {
            _context.StudentClassSubjects.Add(studentClassSubject);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(StudentClassSubject studentClassSubject)
        {
            try
            {
                StudentClassSubject? cs = GetById(studentClassSubject.StudentClassSubjectId);
                cs.IsDelete = true;
                _context.StudentClassSubjects.Update(cs);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean Update(StudentClassSubject studentClassSubject)
        {
            try
            {
                StudentClassSubject? cs = GetById(studentClassSubject.StudentClassSubjectId);
                //cs.SubjectId = classSubject.SubjectId;
                //cs.SemesterId = classSubject.SemesterId;
                //cs.TeacherId = classSubject.TeacherId;
                //cs.ClassId = classSubject.ClassId;
                _context.StudentClassSubjects.Update(cs);
                _context.SaveChanges();
                if (_context.SaveChanges() > 0)
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
