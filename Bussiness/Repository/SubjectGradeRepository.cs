using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;
using System.Diagnostics;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class SubjectGradeRepository : ISubjectGradeRepository
    {
        SubjectGradeManager manager;
        DataContext _context;
        IMapper _mapper;

        public SubjectGradeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new SubjectGradeManager(_context);
        }


        public bool Create(SubjectGradeDTO subjectGradeDTO)
        {
            if (GetBySubjectIdGradeId(subjectGradeDTO.SubjectId, subjectGradeDTO.GradeId) == null)
            {
                SubjectGrade subjectGrade = _mapper.Map<SubjectGrade>(subjectGradeDTO);
                manager.Create(subjectGrade);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(SubjectGradeDTO subjectGradeDTO)
        {
            if (GetBySubjectIdGradeId(subjectGradeDTO.SubjectId, subjectGradeDTO.GradeId) != null)
            {
                SubjectGrade subjectGrade = _mapper.Map<SubjectGrade>(subjectGradeDTO);
                manager.Delelte(subjectGrade);
                return true;
            }
            else
            {
                return false;
            }
        }

        public SubjectGradeDTO GetBySubjectId(int subjectId)
        {
            return _mapper.Map<SubjectGradeDTO>(manager.GetBySubjectId(subjectId));
        }

        public SubjectGradeDTO GetBySubjectIdGradeId(int subjectId, int gradeId)
        {
            return _mapper.Map<SubjectGradeDTO>(manager.GetBySubjectGradeId(subjectId,gradeId)); 
        }

        public List<SubjectGradeDTO> GetList()
        {
            List<SubjectGradeDTO> subjectGradeDTOs;
            subjectGradeDTOs = _mapper.Map<List<SubjectGradeDTO>>(manager.GetList());
            return subjectGradeDTOs;
        }

        public bool Update(SubjectGradeDTO subjectGradeDTO)
        {
            if (GetBySubjectIdGradeId(subjectGradeDTO.SubjectId, subjectGradeDTO.GradeId) != null)
            {
                SubjectGrade subjectGrade = _mapper.Map<SubjectGrade>(subjectGradeDTO);
                manager.Update(subjectGrade);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
