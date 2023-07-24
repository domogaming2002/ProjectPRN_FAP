using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class ClassTranscriptRepository : IClassTranscriptRepository
    {
        StudentClassSubjectManager studentClassSubjectManager;
        TranscriptManager transcriptManager;
        DetailScoreManager detailScoreManager;
        GradeManager gradeManager;
        DataContext _context;
        IMapper _mapper;

        public ClassTranscriptRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            studentClassSubjectManager = new StudentClassSubjectManager(_context);
            transcriptManager = new TranscriptManager(_context);
            detailScoreManager = new DetailScoreManager(_context);
            gradeManager = new GradeManager(_context);
        }
        public List<ClassTranscriptDTO> GetList(int classSubjectId)
        {
            List<ClassTranscriptDTO> classTranscriptDTOs = new List<ClassTranscriptDTO>();
            List<TranscriptDTO> transcriptDTOs = _mapper.Map<List<TranscriptDTO>>(transcriptManager.GetByClassSubjectId(classSubjectId));
            foreach (TranscriptDTO transcriptDTO in transcriptDTOs)
            {
                ClassTranscriptDTO c = new ClassTranscriptDTO();
                c.ClasSubjectId = classSubjectId;
                c.TranscriptDTO = transcriptDTO;
                c.DetailScoreDTOs = _mapper.Map<List<DetailScoreDTO>>(detailScoreManager.GetByTranscriptId(transcriptDTO.TranscriptId));
                classTranscriptDTOs.Add(c);
            }

            return classTranscriptDTOs;
        }
    }
}
