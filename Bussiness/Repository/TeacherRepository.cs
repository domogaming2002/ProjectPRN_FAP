using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        TeacherManager manager;
        DataContext _context;
        IMapper _mapper;

        public TeacherRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new TeacherManager(_context);
        }
        public bool Create(TeacherDTO teacherDTO)
        {
            if (GetById(teacherDTO.TeacherId) == null)
            {
                manager.Create(_mapper.Map<Teacher>(teacherDTO));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delelte(TeacherDTO teacherDTO)
        {

            if (GetById(teacherDTO.TeacherId) != null)
            {
                manager.Delelte(_mapper.Map<Teacher>(teacherDTO));
                return true;
            }
            else
            {
                return false;
            }
        }

        public TeacherDTO? GetById(int teacherId)
        {
            return _mapper.Map<TeacherDTO>(manager.GetById(teacherId));
        }

        public List<TeacherDTO>? GetList()
        {
            return _mapper.Map<List<TeacherDTO>>(manager.GetList());
        }

        public bool Update(TeacherDTO teacherDTO)
        {
            if (GetById(teacherDTO.TeacherId) != null)
            {
                manager.Update(_mapper.Map<Teacher>(teacherDTO));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
