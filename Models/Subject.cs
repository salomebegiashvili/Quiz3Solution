using System.Collections.Generic;

namespace Quiz3Solution.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public int MaximumCapacity { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
