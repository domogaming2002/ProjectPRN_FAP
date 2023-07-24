using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class ClassGradeRepository : IClassGradeRepository
    {

        StudentClassSubjectManager studentClassSubjectManager;
        TranscriptManager transcriptManager;
        DetailScoreManager detailScoreManager;
        GradeManager gradeManager;
        DataContext _context;
        IMapper _mapper;

        public ClassGradeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            studentClassSubjectManager = new StudentClassSubjectManager(_context);
            transcriptManager = new TranscriptManager(_context);
            detailScoreManager = new DetailScoreManager(_context);
            gradeManager = new GradeManager(_context);
        }
        public ClassGradeDTO GetData(int classSubjectId, int gradeId)
        {
            List<Transcript> transcript = transcriptManager.GetByClassSubjectId(classSubjectId);
            ClassGradeDTO dto = new ClassGradeDTO();
            dto.ClassSubjectId = classSubjectId;
            dto.GradeId = gradeId;
            dto.Grade = gradeManager.GetById(gradeId);
            dto.Student = studentClassSubjectManager.GetListByClassSubjectId(classSubjectId);
            dto.DetailScores = new List<DetailScoreDTO>();
            foreach (Transcript t in transcript)
            {
                if (detailScoreManager.GetByTranscriptIdGradeId(t.TranscriptId, gradeId) != null)
                {

                    dto.DetailScores.Add(_mapper.Map<DetailScoreDTO>(detailScoreManager.GetByTranscriptIdGradeId(t.TranscriptId, gradeId)));
                }
            }

            return dto;
        }
    }
}
