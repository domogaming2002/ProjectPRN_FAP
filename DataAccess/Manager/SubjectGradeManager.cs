using PRN221_Project_RazorPage.DataAccess.Data;
using PRN221_Project_WPF.DataAccess.Models;

namespace PRN221_Project_RazorPage.DataAccess.Manager
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

        public SubjectGrade? GetById(int subjectGradeId, int gradeId)
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
                _context.SubjectGrades.Remove(subjectGrade);
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
