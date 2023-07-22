using ProjectPRN_FAP.Bussiness.DTO;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IGradeRepository
    {
        List<GradeDTO> GetList();
        GradeDTO GetById(int id);
        bool Create(GradeDTO grade);
        bool Update(GradeDTO grade);
        bool Delete(GradeDTO grade);
    }
}
