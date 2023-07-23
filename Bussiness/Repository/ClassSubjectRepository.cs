using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class ClassSubjectRepository : IClassSubjectRepository
    {
        ClassSubjectManager manager;
        DataContext _context;
        IMapper _mapper;

        public ClassSubjectRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new ClassSubjectManager(_context);
        }

        public bool Create(ClassSubjectDTO classSubjectDTO)
        {
            if (GetById(classSubjectDTO.ClassSubjectId) == null)
            {
                return manager.Create(_mapper.Map<ClassSubject>(classSubjectDTO)); ;
            }
            else
            {
                return false;
            }
        }

        public bool Delelte(ClassSubjectDTO classSubjectDTO)
        {
            if (GetById(classSubjectDTO.ClassSubjectId) != null)
            {
                return manager.Delelte(_mapper.Map<ClassSubject>(classSubjectDTO)); ;
            }
            else
            {
                return false;
            }
        }

        public ClassSubjectDTO? GetById(int classSubjectId)
        {
            return _mapper.Map<ClassSubjectDTO>(manager.GetById(classSubjectId));
        }

        public List<ClassSubjectDTO>? GetList()
        {
            return _mapper.Map<List<ClassSubjectDTO>>(manager.GetList()); ;
        }

        public List<ClassSubjectDTO>? GetListBySemester(int semesterId)
        {
            return _mapper.Map<List<ClassSubjectDTO>>(manager.GetListBySemester(semesterId)); ;
        }

        public bool Update(ClassSubjectDTO classSubjectDTO)
        {
            if (GetById(classSubjectDTO.ClassSubjectId) != null)
            {
                return manager.Update(_mapper.Map<ClassSubject>(classSubjectDTO)); 
            }
            else
            {
                return false;
            }
        }
    }
}
