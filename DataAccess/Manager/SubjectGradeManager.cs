using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class SubjectGradeManager
    {
        DataContext _context;
        public SubjectGradeManager(DataContext context)
        { _context = context; }

        public List<SubjectGrade>? GetList()
        {
            return _context.SubjectGrades.ToList();
        }

        public SubjectGrade? GetBySubjectId(int subjectId)
        {
            return _context.SubjectGrades.FirstOrDefault(s => s.SubjectId == subjectId);
        }

        public SubjectGrade? GetBySubjectGradeId(int subjectGradeId, int gradeId)
        {
            return _context.SubjectGrades.FirstOrDefault(s => s.SubjectId == subjectGradeId && s.GradeId == gradeId);
        }

        public Boolean Create(SubjectGrade subjectGrade)
        {
            _context.SubjectGrades.Add(subjectGrade);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(SubjectGrade subjectGrade)
        {
            try
            {
                SubjectGrade subject = _context.SubjectGrades.FirstOrDefault(s => s.SubjectId == subjectGrade.SubjectId && s.GradeId == subjectGrade.GradeId);
                subject.IsDelete = true;
                _context.SubjectGrades.Update(subject);
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

        public Boolean Update(SubjectGrade subjectGrade)
        {
            try
            {
                _context.SubjectGrades.Update(subjectGrade);
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
