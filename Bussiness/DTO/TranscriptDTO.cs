using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class TranscriptDTO
    {
        public int TranscriptId { get; set; }
        public int SubjectId { get; set; }
        public int ClassSubjectId { get; set; }

        public int StudentId { get; set; }
        public Double TotalScore { get; set; }
        public bool IsDelete { get; set; }

        public Student Students { get; set; }
        public Subject Subject { get; set; }
        public ClassSubject ClassSubject { get; set; }


        public ICollection<DetailScore> DetailScores { get; set; }
    }
}
