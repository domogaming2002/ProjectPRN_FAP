using ProjectPRN_FAP.Bussiness.DTO;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IClassTranscriptRepository
    {
       List<ClassTranscriptDTO> GetList(int classSubjectId);
    }
}
