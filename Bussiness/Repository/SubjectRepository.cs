using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        SubjectManager manager;
        DataContext _context;
        IMapper _mapper;

        public SubjectRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new SubjectManager(_context);
        }
        public bool Create(SubjectDTO subject)
        {
            if (GetById(subject.SubjectId) == null)
            {
                Subject subject1 = _mapper.Map<Subject>(subject);
                manager.Create(subject1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(SubjectDTO subject)
        {
            if (GetById(subject.SubjectId) != null)
            {
                Subject subject1 = _mapper.Map<Subject>(subject);
                manager.Delelte(subject1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public SubjectDTO GetById(int id)
        {
            return _mapper.Map<SubjectDTO>(manager.GetById(id));
        }

        public List<SubjectDTO> GetList()
        {
            List<SubjectDTO> subjectDTOs;
            subjectDTOs = _mapper.Map<List<SubjectDTO>>(manager.GetList());
            return subjectDTOs;
        }

        public bool Update(SubjectDTO subject)
        {
            if (GetById(subject.SubjectId) != null)
            {
                Subject subject1 = _mapper.Map<Subject>(subject);
                manager.Update(subject1);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
