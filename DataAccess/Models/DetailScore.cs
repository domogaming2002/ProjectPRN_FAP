using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN_FAP.DataAccess.Models
{
    public class DetailScore
    {
        [Key]
        public int DetailScoreId { get; set; }
        [Required]
        public int TranscriptId { get; set; }
        [Required]
        public int GradeId { get; set; }
        [AllowNull]
        public double Score { get; set; }

        public Transcript Transcript { get; set; }
        [Required]
        public bool IsDelete { get; set; }
    }
}
