using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class GradeRepository : IGradeRepository
    {
        GradeManager manager;
        DataContext _context;
        IMapper _mapper;

        public GradeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new GradeManager(_context);
        }

        public bool Create(GradeDTO grade)
        {
            if (GetById(grade.GradeID) == null)
            {
                Grade grade1 = _mapper.Map<Grade>(grade);
                manager.Create(grade1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(GradeDTO grade)
        {
            if (GetById(grade.GradeID) != null)
            {
                Grade grade1 = _mapper.Map<Grade>(grade);
                manager.Delelte(grade1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public GradeDTO GetById(int id)
        {
            return _mapper.Map<GradeDTO>(manager.GetById(id));
        }

        public List<GradeDTO> GetList()
        {
            List<GradeDTO> gradeDTOs;
            gradeDTOs = _mapper.Map<List<GradeDTO>>(manager.GetList());
            return gradeDTOs;
        }


        public bool Update(GradeDTO grade)
        {
            if (GetById(grade.GradeID) != null)
            {
                Grade grade1 = _mapper.Map<Grade>(grade);
                manager.Update(grade1);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
