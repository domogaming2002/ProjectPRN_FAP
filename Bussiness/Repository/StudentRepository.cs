using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class StudentRepository : IStudentRepository
    {
        StudentManager manager;
        DataContext _context;
        IMapper _mapper;

        public StudentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new StudentManager(_context);
        }
        public bool Create(StudentDTO studentDTO)
        {
            if (GetById(studentDTO.StudentId) == null)
            {
                manager.Create(_mapper.Map<Student>(studentDTO));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delelte(StudentDTO studentDTO)
        {
            if (GetById(studentDTO.StudentId) != null)
            {
                manager.Delelte(_mapper.Map<Student>(studentDTO));
                return true;
            }
            else
            {
                return false;
            }
        }

        public StudentDTO? GetById(int studentId)
        {
            return _mapper.Map<StudentDTO>(manager.GetById(studentId));
        }

        public StudentDTO? GetByUserId(int userId)
        {
            return _mapper.Map<StudentDTO>(manager.GetByUserId(userId));
        }

        public List<StudentDTO>? GetList()
        {
            return _mapper.Map<List<StudentDTO>>(manager.GetList());
        }

        public bool Update(StudentDTO studentDTO)
        {
            if (GetById(studentDTO.StudentId) != null)
            {
                manager.Update(_mapper.Map<Student>(studentDTO));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
