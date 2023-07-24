using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class SemesterManager
    {
        DataContext _context;
        public SemesterManager(DataContext context)
        { _context = context; }

        public List<Semester>? GetList()
        {
            return _context.Semesters.Where(s => s.IsDelete == false).ToList();
        }

        public Semester? GetById(int semesterId)
        {
            return _context.Semesters.FirstOrDefault(s => s.SemesterId == semesterId);
        }

        public Boolean Create(Semester semester)
        {
            _context.Semesters.Add(semester);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(Semester semester)
        {
            try
            {
                Semester semester1 = GetById(semester.SemesterId);
                semester1.IsDelete = true;
                _context.Semesters.Update(semester1);
                _context.SaveChanges();
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean Update(Semester semester)
        {
            try
            {
                Semester semester1 = GetById(semester.SemesterId);

                semester1.SemesterName = semester.SemesterName;
                semester1.StartDate = semester.StartDate;
                semester1.EndDate = semester.EndDate;

                _context.Semesters.Update(semester1);
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
