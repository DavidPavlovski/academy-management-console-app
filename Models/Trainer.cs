using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Models
{
    public class Trainer : User
    {
        public Trainer(string userName, string firstName, string lastName, string email, string password)
            : base(userName, firstName, lastName, email, password) { }


        public void PrintStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student.GetInfo());
            }
        }
        public void PrintStudents(List<Student> students, string searchTerm)
        {
            List<Student> foundStudents = students.Where(s => s.FullName.ToLower().Contains(searchTerm.ToLower())).ToList();
            if (foundStudents.Count() == 0)
            {
                Console.WriteLine($"No results were found for : {searchTerm}");
                return;
            }
            Console.WriteLine($"Searrch results for : {searchTerm}");
            foreach (Student student in foundStudents)
            {
                Console.WriteLine(student.GetInfo());
            }
        }
        public void PrintSubjects()
        {
            foreach (Subjects s in Enum.GetValues(typeof(Subjects)))
            {
                Console.WriteLine($"-{s}");
            }
        }
    }
}
