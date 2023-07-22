using ProjectPRN_FAP.Bussiness.DTO;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface ISubjectGradeRepository
    {
        List<SubjectGradeDTO> GetList();

        SubjectGradeDTO GetBySubjectId(int subjectId);
        SubjectGradeDTO GetBySubjectIdGradeId(int subjectId, int gradeId);
        bool Create(SubjectGradeDTO subjectGradeDTO);
        bool Update(SubjectGradeDTO subjectGradeDTO);
        bool Delete(SubjectGradeDTO subjectGradeDTO);
    }
}
