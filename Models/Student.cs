using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Student : User
    {
        public Subjects CurrentSubject { get; set; }
        public List<Subject> Grades { get; set; }
        public Student(string userName, string firstName, string lastName, string email, string password)
            : base(userName, firstName, lastName, email, password)
        {
        }

        public Student(string userName, string firstName, string lastName, string email, string password, Subjects currentSubject, List<Subject> grades)
             : base(userName, firstName, lastName, email, password)
        {
            CurrentSubject = currentSubject;
            Grades = grades;
        }

        public string GetInfo()
        {
            return $"{FullName} - ({Email})";
        }
        public void GetGrades()
        {
            if (Grades == null || Grades.Count == 0)
            {
                Console.WriteLine("You dont have any grades yet.");
                return;
            }
            foreach (Subject grade in Grades)
            {
                Console.WriteLine($"{grade.SubjectName} ({grade.Grade})");
            }
        }
    }
}

