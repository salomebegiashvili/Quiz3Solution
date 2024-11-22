using System;
using Quiz3Solution.Models;
using Quiz3Solution.Data;

namespace Quiz3Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new ApplicationContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var repository = new Repository(context);

            var math = new Subject { Title = "Math", MaximumCapacity = 30 };
            repository.AddSubject(math);

            var alice = new Student { Name = "Alice", EnrollmentDate = DateTime.Now };
            var bob = new Student { Name = "Bob", EnrollmentDate = DateTime.Now };

            repository.AddStudent(alice);
            repository.AddStudent(bob);

            repository.EnrollStudentToSubject(alice.StudentId, math.SubjectId);
            repository.EnrollStudentToSubject(bob.StudentId, math.SubjectId);

            var subjects = repository.GetAllSubjects();
            foreach (var subject in subjects)
            {
                Console.WriteLine($"Subject: {subject.Title}");
                foreach (var student in subject.Students)
                {
                    Console.WriteLine($" - {student.Name}");
                }
            }
        }
    }
}
