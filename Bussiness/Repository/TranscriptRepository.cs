using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class TranscriptRepository : ITranscriptRepository
    {
        TranscriptManager manager;
        DataContext _context;
        IMapper _mapper;

        public TranscriptRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new TranscriptManager(_context);
        }
        public bool Create(TranscriptDTO transcript)
        {
            if (GetById(transcript.TranscriptId) == null)
            {
                return manager.Create(_mapper.Map<Transcript>(transcript)); ;
            }
            else
            {
                return false;
            }
        }

        public bool Delelte(TranscriptDTO transcript)
        {
            if (GetById(transcript.TranscriptId) != null)
            {
                return manager.Delelte(_mapper.Map<Transcript>(transcript)); ;
            }
            else
            {
                return false;
            }
        }

        public TranscriptDTO? GetByAllId(int classSubjectId, int studentId, int subjectId)
        {
            return _mapper.Map<TranscriptDTO>(manager.GetByAllId(classSubjectId, studentId, subjectId));
        }

        public List<TranscriptDTO>? GetByClassSubjectId(int classSubjectId)
        {
            return _mapper.Map<List<TranscriptDTO>>(manager.GetByClassSubjectId(classSubjectId));
        }

        public TranscriptDTO? GetById(int transcriptId)
        {
            return _mapper.Map<TranscriptDTO>(manager.GetById(transcriptId));
        }

        public List<TranscriptDTO>? GetByStudentId(int studentId)
        {
            return _mapper.Map<List<TranscriptDTO>>(manager.GetByStudentId(studentId));
        }

        public int GetLastInsertTranscriptId()
        {
            return manager.GetLastInsertTranscriptId();
        }

        public List<TranscriptDTO>? GetList()
        {
            return _mapper.Map<List<TranscriptDTO>>(manager.GetList());
        }

        public bool Update(TranscriptDTO transcript)
        {
            if (GetById(transcript.TranscriptId) != null)
            {
                return manager.Update(_mapper.Map<Transcript>(transcript)); ;
            }
            else
            {
                return false;
            }
        }
    }
}
