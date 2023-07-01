using AutoMapper;
using AutoMapper.Execution;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
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
            if (GetById(semester.SemesterId) != null)
            {
                Semester semester1 = _mapper.Map<Semester>(semester);
                manager.Delelte(semester1);
                return true;
            }
            else
            {
                return false;
            }
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
            if (GetById(semester.SemesterId) != null)
            {
                Semester semester1 = _mapper.Map<Semester>(semester);
                manager.Update(semester1);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
