using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class StudentClassSubjectRepository : IStudentClassSubjectRepository
    {

        StudentClassSubjectManager manager;
        DataContext _context;
        IMapper _mapper;

        public StudentClassSubjectRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new StudentClassSubjectManager(_context);
        }

        public bool Create(StudentClassSubjectDTO studentClassSubject)
        {
            if (GetById(studentClassSubject.StudentClassSubjectId) == null)
            {
                return manager.Create(_mapper.Map<StudentClassSubject>(studentClassSubject)); ;
            }
            else
            {
                return false;
            }
        }

        public bool Delelte(StudentClassSubjectDTO studentClassSubject)
        {
            if (GetById(studentClassSubject.StudentClassSubjectId) != null)
            {
                return manager.Delelte(_mapper.Map<StudentClassSubject>(studentClassSubject)); ;
            }
            else
            {
                return false;
            }
        }

        public StudentClassSubjectDTO? GetById(int studentClassSubjectId)
        {
            return _mapper.Map<StudentClassSubjectDTO>(manager.GetById(studentClassSubjectId));
        }

        public StudentClassSubjectDTO? GetByStudentIdClassSubjectId(int studentId, int classSubjectId)
        {
            return _mapper.Map<StudentClassSubjectDTO>(manager.GetByStudentIdClassSubjectId(studentId, classSubjectId)) ;
        }

        public List<StudentClassSubjectDTO>? GetList()
        {
            return _mapper.Map<List<StudentClassSubjectDTO>>(manager.GetList());
        }

        public List<StudentClassSubjectDTO>? GetListByClassSubjectId(int classSubjectId)
        {
            return _mapper.Map<List<StudentClassSubjectDTO>>(manager.GetListByClassSubjectId(classSubjectId));
        }

        public List<StudentClassSubjectDTO>? GetListByStudentId(int studentId)
        {
            return _mapper.Map<List<StudentClassSubjectDTO>>(manager.GetListByStudentId(studentId));
        }

        public bool Update(StudentClassSubjectDTO studentClassSubject)
        {
            if (GetById(studentClassSubject.StudentClassSubjectId) != null)
            {
                return manager.Update(_mapper.Map<StudentClassSubject>(studentClassSubject)); ;
            }
            else
            {
                return false;
            }
        }
    }
}
