using ProjectPRN_FAP.Bussiness.DTO;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IClassGradeRepository
    {
        ClassGradeDTO GetData(int classSubjectId, int gradeId);
    }
}
