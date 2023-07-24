using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class TranscriptManager
    {
        DataContext _context;
        public TranscriptManager(DataContext context)
        { _context = context; }

        public List<Transcript>? GetList()
        {
            return _context.Transcripts.Where(t => t.IsDelete == false).ToList();
        }

        public Transcript? GetById(int transcriptId)
        {
            return _context.Transcripts.FirstOrDefault(s => s.TranscriptId == transcriptId && s.IsDelete == false);
        }

        public List<Transcript>? GetByClassSubjectId(int classSubjectId)
        {
            return _context.Transcripts.Include(t => t.Students).Include(t => t.Students.User).Where(s => s.ClassSubjectId == classSubjectId && s.IsDelete == false).ToList();

        }
        public List<Transcript>? GetByStudentId(int studentId)
        {
            return _context.Transcripts.Include(t => t.Students).Include(t => t.Students.User)
                .Include(t => t.ClassSubject).Include(t => t.ClassSubject.Class)
                .Include(t => t.Subject).Include(t => t.ClassSubject.Semester)
                .Where(s => s.StudentId == studentId && s.IsDelete == false).ToList();
        }

        public Boolean Create(Transcript transcript)
        {
            _context.Transcripts.Add(transcript);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(Transcript transcript)
        {
            try
            {
                Transcript t = GetById(transcript.TranscriptId);
                t.IsDelete = true;
                _context.Transcripts.Remove(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean Update(Transcript transcript)
        {
            try
            {
                Transcript t = GetById(transcript.TranscriptId);
                //teacherUpdate.TeacherCode = teacher.TeacherCode;
                _context.Transcripts.Update(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int GetLastInsertTranscriptId()
        {
            Transcript? t = _context.Transcripts.OrderBy(t => t.TranscriptId).LastOrDefault();
            return t.TranscriptId;
        }
    }
}
