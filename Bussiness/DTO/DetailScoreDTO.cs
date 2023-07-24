using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class DetailScoreDTO
    {
        public int DetailScoreId { get; set; }
        public int TranscriptId { get; set; }
        public int GradeId { get; set; }
        public double Score { get; set; }

        public Transcript Transcript { get; set; }
        public bool IsDelete { get; set; }
    }
}
