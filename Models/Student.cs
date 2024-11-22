using System;
using System.Collections.Generic;

namespace Quiz3Solution.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
