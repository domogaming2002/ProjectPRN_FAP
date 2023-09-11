using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class DetailScoreManager
    {
        DataContext _context;
        public DetailScoreManager(DataContext context)
        { _context = context; }

        public List<DetailScore>? GetList()
        {
            return _context.DetailScores.Where(t => t.IsDelete == false).ToList();
        }

        public DetailScore? GetById(int detailScoreId)
        {
            return _context.DetailScores.FirstOrDefault(s => s.DetailScoreId == detailScoreId && s.IsDelete == false);
        }

        public DetailScore? GetByTranscriptIdGradeId(int transcriptId , int gradeId)
        {
            return _context.DetailScores.FirstOrDefault(s => s.TranscriptId == transcriptId  && s.GradeId == gradeId && s.IsDelete == false);
        }


        public List<DetailScore>? GetByTranscriptId(int transcriptId)
        {
            return _context.DetailScores.Where(s => s.TranscriptId == transcriptId && s.IsDelete == false).ToList();
        }

        public Boolean Create(DetailScore detailScore)
        {
            _context.DetailScores.Add(detailScore);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean Delelte(DetailScore detailScore)
        {
            try
            {
                DetailScore t = GetById(detailScore.DetailScoreId);
                t.IsDelete = true;
                _context.DetailScores.Update(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean Update(DetailScore detailScore)
        {
            try
            {
                DetailScore t = GetById(detailScore.DetailScoreId);
                t.Score = detailScore.Score;
                _context.DetailScores.Update(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
