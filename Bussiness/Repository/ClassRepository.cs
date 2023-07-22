using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class ClassRepository : IClassRepository
    {
        ClassManager manager;
        DataContext _context;
        IMapper _mapper;

        public ClassRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new ClassManager(_context);
        }
        public bool Create(ClassDTO classes)
        {
            if (GetById(classes.ClassId) == null)
            {
                Class classe = _mapper.Map<Class>(classes);
                manager.Create(classe);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(ClassDTO classes)
        {
            if (GetById(classes.ClassId) != null)
            {
                Class classe = _mapper.Map<Class>(classes);
                manager.Delelte(classe);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ClassDTO GetById(int id)
        {
            return _mapper.Map<ClassDTO>(manager.GetById(id));
        }

        public List<ClassDTO> GetList()
        {
            List<ClassDTO> classDTOs;
            classDTOs = _mapper.Map<List<ClassDTO>>(manager.GetList());
            return classDTOs;
        }

        public bool Update(ClassDTO classes)
        {
            if (GetById(classes.ClassId) != null)
            {
                Class classe = _mapper.Map<Class>(classes);
                manager.Update(classe);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
