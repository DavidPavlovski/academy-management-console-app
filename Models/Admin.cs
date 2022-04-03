using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Models
{
    public class Admin : User
    {
        public Admin(string userName, string firstName, string lastName, string email, string password)
            : base(userName, firstName, lastName, email, password) { }


        public void AddUser(List<User> users, List<Student> students, Student newStudent)
        {
            if (users.Any(u => u.UserName == newStudent.UserName || u.Email == newStudent.Email))
            {
                throw new Exception("Username or email already in use , try again.");
            }
            students.Add(newStudent);
            users.Add(newStudent);
        }

        public void AddUser(List<User> users, List<Trainer> trainers, Trainer newTrainer)
        {
            if (users.Any(u => u.UserName == newTrainer.UserName || u.Email == newTrainer.Email))
            {
                throw new Exception("Username or email already in use , try again.");
            }
            users.Add(newTrainer);
            trainers.Add(newTrainer);
        }

        public void AddUser(List<User> users, List<Admin> admins, Admin newAdmin)
        {
            if (users.Any(u => u.UserName == newAdmin.UserName || u.Email == newAdmin.Email))
            {
                throw new Exception("Username or email already in use , try again.");
            }
            admins.Add(newAdmin);
            users.Add(newAdmin);
        }

        public void RemoveUser(List<User> users, List<Student> students, string removeBy)
        {
            Student studentToRemove = students.FirstOrDefault(s => s.UserName == removeBy || s.Email == removeBy);
            students.Remove(studentToRemove);
            users.Remove(studentToRemove);
        }

        public void RemoveUser(List<User> users, List<Trainer> trainers, string removeBy)
        {
            Trainer trainerToRemove = trainers.FirstOrDefault(t => t.UserName == removeBy || t.Email == removeBy);
            trainers.Remove(trainerToRemove);
            users.Remove(trainerToRemove);
        }

        public void RemoveUser(List<User> users, Admin loggedInAdmin, List<Admin> admins, string removeBy)
        {
            if (loggedInAdmin.UserName == removeBy || loggedInAdmin.Email == removeBy)
            {
                throw new Exception("Cannot remove self!");
            }
            Admin adminToRemove = admins.FirstOrDefault(a => a.UserName == removeBy || a.Email == removeBy);
            admins.Remove(adminToRemove);
            users.Remove(adminToRemove);
        }
    }
}
