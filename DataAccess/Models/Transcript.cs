using ProjectPRN_FAP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN_FAP.DataAccess.Models
{
    public class Transcript
    {
        [Key]
        public int TranscriptId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int ClassSubjectId { get; set; }

        [Required]
        public int StudentId { get; set; }
        [AllowNull]
        public Double TotalScore { get; set; }
        [Required]
        public bool IsDelete { get; set; }

        public Student Students { get; set; }
        public Subject Subject { get; set; }
        public ClassSubject ClassSubject { get; set; }


        public ICollection<DetailScore> DetailScores { get; set; }
        
    }
}
