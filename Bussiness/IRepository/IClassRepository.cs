using ProjectPRN_FAP.Bussiness.DTO;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IClassRepository
    {
        List<ClassDTO> GetList();

        ClassDTO GetById(int id);
        bool Create(ClassDTO classes);
        bool Update(ClassDTO classes);
        bool Delete(ClassDTO classes);
    }
}
