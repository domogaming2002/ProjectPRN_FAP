using PRN221_Project_RazorPage.Bussiness.DTO;

namespace PRN221_Project_RazorPage.Bussiness.IRepository
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
