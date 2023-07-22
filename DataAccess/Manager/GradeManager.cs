using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class GradeManager
    {
        DataContext _context;
        public GradeManager(DataContext context)
        { _context = context; }

        public List<Grade>? GetList()
        {
            return _context.Grades.Where(g => g.IsDelete == false).ToList();
        }

        public Grade? GetById(int gradeId)
        {
            return _context.Grades.FirstOrDefault(s => s.GradeID == gradeId);
        }

        public Boolean Create(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(Grade grade)
        {
            try
            {
                Grade grade1 = GetById(grade.GradeID);
                grade1.IsDelete = true;
                _context.Grades.Update(grade1);
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

        public Boolean Update(Grade grade)
        {
            try
            {
                Grade grade1 = GetById(grade.GradeID);
                grade1.GradeName = grade.GradeName;
                grade1.Percent = grade.Percent;
                _context.Grades.Update(grade1);
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
