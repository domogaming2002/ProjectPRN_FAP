using ProjectPRN_FAP.Bussiness.DTO;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface ISubjectRepository
    {
        List<SubjectDTO> GetList();

        SubjectDTO GetById(int id);
        bool Create(SubjectDTO subject);
        bool Update(SubjectDTO subject);
        bool Delete(SubjectDTO subject);
    }
}
