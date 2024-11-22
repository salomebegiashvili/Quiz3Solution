using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quiz3Solution.Models;

namespace Quiz3Solution.Data
{
    public class Repository
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void EnrollStudentToSubject(int studentId, int subjectId)
        {
            var student = _context.Students.Find(studentId);
            var subject = _context.Subjects.Find(subjectId);

            if (student != null && subject != null)
            {
                subject.Students.Add(student);
                _context.SaveChanges();
            }
        }

        public List<Subject> GetAllSubjects()
        {
            return _context.Subjects.Include(s => s.Students).ToList();
        }

        public List<Student> GetStudentsForSubject(int subjectId)
        {
            var subject = _context.Subjects.Include(s => s.Students)
                                            .FirstOrDefault(s => s.SubjectId == subjectId);
            return subject?.Students ?? new List<Student>();
        }
    }
}
