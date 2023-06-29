﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_Project_WPF.DataAccess.Models
{
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }
        [Required]
        public string GradeName { get; set; }
        [Required]
        public double Percent { get; set; }
        public ICollection<SubjectGrade> SubjectGrades { get; set; }
        [Required]
        public Boolean isDelete;
    }
}
