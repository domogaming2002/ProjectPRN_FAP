using AutoMapper;
using AutoMapper.Execution;
using PRN221_Project_RazorPage.Bussiness.DTO;
using PRN221_Project_RazorPage.Bussiness.IRepository;
using PRN221_Project_RazorPage.DataAccess.Data;
using PRN221_Project_RazorPage.DataAccess.Manager;
using PRN221_Project_RazorPage.DataAccess.Models;

namespace PRN221_Project_RazorPage.Bussiness.Repository
{
    public class SemesterRepository : ISemesterRepository
    {
        SemesterManager manager;
        DataContext _context;
        IMapper _mapper;

        public SemesterRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new SemesterManager(_context);
        }

        public bool Create(SemesterDTO semester)
        {
            if (GetById(semester.SemesterId) == null)
            {
                Semester semester1 = _mapper.Map<Semester>(semester);
                manager.Create(semester1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(SemesterDTO semester)
        {
            throw new NotImplementedException();
        }

        public SemesterDTO GetById(int id)
        {
            return _mapper.Map<SemesterDTO>(manager.GetById(id));
        }

        public List<SemesterDTO> GetList()
        {
            List<SemesterDTO> semesterDTOs;


            semesterDTOs = _mapper.Map<List<SemesterDTO>>(manager.GetList());
            return semesterDTOs;
        }

        public bool Update(SemesterDTO semester)
        {
            throw new NotImplementedException();
        }
    }
}
