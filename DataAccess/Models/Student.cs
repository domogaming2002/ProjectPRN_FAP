﻿using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } 
       
        [Required]
        public int UserId { get; set; }
        [Required]
        public String StudentCode { get; set; }
        [Required]
        public bool IsDelete { get; set; }

        public User User { get; set; }
        
        public ICollection<StudentClassSubject> StudentClassSubjects { get; set; }
        public ICollection<Transcript> Transcripts { get; set; }
    }
}
