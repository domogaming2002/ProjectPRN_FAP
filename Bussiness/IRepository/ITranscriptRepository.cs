using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface ITranscriptRepository
    {
        List<TranscriptDTO>? GetList();

        TranscriptDTO? GetById(int transcriptId);

        List<TranscriptDTO>? GetByClassSubjectId(int classSubjectId);
        List<TranscriptDTO>? GetByStudentId(int studentId);

        Boolean Create(TranscriptDTO transcript);

        Boolean Delelte(TranscriptDTO transcript);

        Boolean Update(TranscriptDTO transcript);
        int GetLastInsertTranscriptId();

    }
}
