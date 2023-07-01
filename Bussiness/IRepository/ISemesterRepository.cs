using ProjectPRN_FAP.Bussiness.DTO;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface ISemesterRepository
    {
        List<SemesterDTO> GetList();

        SemesterDTO GetById(int id);
        bool Create(SemesterDTO semester);
        bool Update(SemesterDTO semester);
        bool Delete(SemesterDTO semester);
    }
}
