using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Subject
    {
        public Subjects SubjectName { get; set; }
        public int Grade { get; set; }

        public Subject(Subjects subjectName, int grade)
        {
            SubjectName = subjectName;
            Grade = grade;
        }
    }
}
