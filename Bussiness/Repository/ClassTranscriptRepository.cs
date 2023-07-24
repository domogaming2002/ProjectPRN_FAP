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
                bool failFE = false;
                bool failFER = false;
                double totalScore = 0;
                ClassTranscriptDTO c = new ClassTranscriptDTO();
                c.ClasSubjectId = classSubjectId;
                c.TranscriptDTO = transcriptDTO;
                c.DetailScoreDTOs = _mapper.Map<List<DetailScoreDTO>>(detailScoreManager.GetByTranscriptId(transcriptDTO.TranscriptId));
                foreach (DetailScoreDTO d in c.DetailScoreDTOs)
                {

                    GradeDTO g = _mapper.Map<GradeDTO>(gradeManager.GetById(d.GradeId));
                    if (g.GradeName == "FE" && d.Score < 4)
                    {
                        c.status = false;
                        failFE = true;
                        break;
                    }
                    else if (d.Score == 0)
                    {
                        c.status = false;
                        break;
                    }
                    totalScore += d.Score * (g.Percent / 100);
                }
                if (totalScore < 5 || failFE)
                {
                    totalScore = 0;
                    foreach (DetailScoreDTO d in c.DetailScoreDTOs)
                    {
                        GradeDTO g = _mapper.Map<GradeDTO>(gradeManager.GetById(d.GradeId));
                        if (g.GradeName != "FE")
                        {
                            if (g.GradeName == "FER" && d.Score < 4)
                            {
                                c.status = false;
                                failFER = true;
                                break;
                            }
                            else if (d.Score == 0)
                            {
                                c.status = false;
                                break;
                            }
                            totalScore += d.Score * (g.Percent / 100);
                        }
                    }
                }
                if (totalScore > 5)
                {
                    c.status = true;
                }
                if (failFER)
                {
                    c.status = false;
                }
                c.TranscriptDTO.TotalScore = totalScore;
                classTranscriptDTOs.Add(c);
            }

            return classTranscriptDTOs;
        }

        public ClassTranscriptDTO GetOneStudentTranscript(int transcriptId)
        {
            ClassTranscriptDTO c = new ClassTranscriptDTO();
            TranscriptDTO transcriptDTO = _mapper.Map<TranscriptDTO>(transcriptManager.GetById(transcriptId));
            bool failFE = false;
            bool failFER = false;
            double totalScore = 0;
            c.ClasSubjectId = transcriptDTO.ClassSubjectId;
            c.TranscriptDTO = transcriptDTO;
            c.DetailScoreDTOs = _mapper.Map<List<DetailScoreDTO>>(detailScoreManager.GetByTranscriptId(transcriptDTO.TranscriptId));
            foreach (DetailScoreDTO d in c.DetailScoreDTOs)
            {
                GradeDTO g = _mapper.Map<GradeDTO>(gradeManager.GetById(d.GradeId));
                if (g.GradeName == "FE" && d.Score < 4)
                {
                    c.status = false;
                    failFE = true;
                    break;
                }
                else if (d.Score == 0)
                {
                    c.status = false;
                    break;
                }
                totalScore += d.Score * (g.Percent / 100);
            }
            if (totalScore < 5 || failFE)
            {
                totalScore = 0;
                foreach (DetailScoreDTO d in c.DetailScoreDTOs)
                {
                    GradeDTO g = _mapper.Map<GradeDTO>(gradeManager.GetById(d.GradeId));
                    if (g.GradeName != "FE")
                    {
                        if (g.GradeName == "FER" && d.Score < 4)
                        {
                            c.status = false;
                            failFER = true;
                            break;
                        }
                        else if (d.Score == 0)
                        {
                            c.status = false;
                            break;
                        }
                        totalScore += d.Score * (g.Percent / 100);
                    }
                }
            }
            if (totalScore > 5)
            {
                c.status = true;
            }
            if (failFER)
            {
                c.status = false;
            }
            c.TranscriptDTO.TotalScore = totalScore;
            return c;
        }

        

    }
}
