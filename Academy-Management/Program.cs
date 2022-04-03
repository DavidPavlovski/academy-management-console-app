using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy_Management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Admin> admins = new List<Admin>();
            Admin a1 = new Admin("admin1.admin", "admin1", "admin2", "admin@email.com", "admin123");
            Admin a2 = new Admin("admin2.admin", "admin2", "admin2", "admin2@email.com", "admin123");
            admins.Add(a1);
            admins.Add(a2);

            List<Trainer> trainers = new List<Trainer>();
            Trainer t1 = new Trainer("bob.bobsky", "Bob", "Bobsky", "bob@email.com", "bob123");
            Trainer t2 = new Trainer("tom.tomsky", "Tom", "Tomsky", "tom@email.com", "tom123");
            trainers.Add(t1);
            trainers.Add(t2);

            List<Student> students = new List<Student>();
            List<Subject> s1Grades = new List<Subject>() { new Subject(Subjects.basicJavascript, 7), new Subject(Subjects.advancedJavascript, 9) };
            List<Subject> s2Grades = new List<Subject>() { new Subject(Subjects.basicsOfWebDevelopment, 6), new Subject(Subjects.basicJavascript, 10) };
            Student s1 = new Student("tim.timsky", "Tim", "Timsky", "tim@email.com", "tim123", Subjects.advancedCsharp, s1Grades);
            Student s2 = new Student("john.johnsky", "John", "Johnsky", "john@email.com", "john123", Subjects.basicCsharp, s2Grades);
            Student s3 = new Student("jane.janesky", "Jane", "Janesky", "jane@email.com", "jane123");
            students.Add(s1);
            students.Add(s2);
            students.Add(s3);

            List<User> allUsers = new List<User>();
            allUsers.AddRange(admins);
            allUsers.AddRange(trainers);
            allUsers.AddRange(students);

            UI(allUsers, admins, trainers, students);
        }

        public static Admin HandleLogIn(List<Admin> admins)
        {
            Console.WriteLine("Enter username or email : ");
            string loginCredentials = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();
            Admin admin = admins.FirstOrDefault(a => a.UserName == loginCredentials || a.Email == loginCredentials);
            if (admin == null || !admin.CheckPassword(password))
            {
                return null;
            }
            return admin;
        }
        public static Trainer HandleLogIn(List<Trainer> trainers)
        {
            Console.WriteLine("Enter username or email : ");
            string userCredentials = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();
            Trainer trainer = trainers.FirstOrDefault(t => t.UserName == userCredentials || t.Email == userCredentials);
            if (trainer == null || !trainer.CheckPassword(password))
            {
                return null;
            }
            return trainer;
        }
        public static Student HandleLogIn(List<Student> students)
        {
            Console.WriteLine("Enter username or email : ");
            string userCredentials = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();
            Student student = students.FirstOrDefault(s => s.UserName == userCredentials || s.Email == userCredentials);
            if (student == null || !student.CheckPassword(password))
            {
                return null;
            }
            return student;
        }

        public static User CreateNewUser()
        {
            Console.WriteLine("Enter username : ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter email : ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter first name : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name : ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter user's password :");
            string userPassword = Console.ReadLine();

            return new User(userName, firstName, lastName, email, userPassword);
        }

        public static void AdminOptions(Admin admin, List<User> allUsers, List<Admin> admins, List<Trainer> trainers, List<Student> students)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {admin.FirstName}");
                Console.WriteLine("Select option :\n1.)Add new student \n2.)Remove student \n3.)Add new trainer \n4.)Remove trainer \n5).Add new admin \n6.)Remove admin\n7.)Logout");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    try
                    {
                        User newUser = CreateNewUser();
                        Student newStudent = new Student(newUser.UserName, newUser.FirstName, newUser.LastName, newUser.Email, newUser.Password);
                        admin.AddUser(allUsers, students, newStudent);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        continue;
                    }
                }
                else if (option == "2")
                {
                    try
                    {

                        Console.WriteLine("Enter userName or email to remove a student : ");
                        string removeBy = Console.ReadLine();
                        Console.WriteLine("Confirm your password");
                        string confirmPassword = Console.ReadLine();
                        if (!admin.CheckPassword(confirmPassword))
                        {
                            throw new Exception("Incorrect password");
                        }
                        admin.RemoveUser(allUsers, students, removeBy);
                        Console.WriteLine($"Successfully removed {removeBy}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        continue;
                    }
                }
                else if (option == "3")
                {
                    try
                    {

                        User newUser = CreateNewUser();
                        Trainer newTrainer = new Trainer(newUser.UserName, newUser.FirstName, newUser.LastName, newUser.Email, newUser.Password);
                        admin.AddUser(allUsers, trainers, newTrainer);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        continue;
                    }
                }
                else if (option == "4")
                {
                    try
                    {
                        Console.WriteLine("Enter userName or email to remove a trainer : ");
                        string removeBy = Console.ReadLine();
                        Console.WriteLine("Confirm your password : ");
                        string confirmPassword = Console.ReadLine();
                        if (!admin.CheckPassword(confirmPassword))
                        {
                            throw new Exception("Incorrect password");
                        }

                        admin.RemoveUser(allUsers, trainers, removeBy);
                        Console.WriteLine($"Successfully removed {removeBy}");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        continue;
                    }
                }
                else if (option == "5")
                {
                    try
                    {
                        User newUser = CreateNewUser();
                        Admin newAdmin = new Admin(newUser.UserName, newUser.FirstName, newUser.LastName, newUser.Email, newUser.Password);
                        admin.AddUser(allUsers, admins, newAdmin);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        continue;
                    }
                }
                else if (option == "6")
                {
                    try
                    {

                        Console.WriteLine("Enter userName or email to remove a admin : ");
                        string removeBy = Console.ReadLine();
                        Console.WriteLine("Confirm your password");
                        string confirmPassword = Console.ReadLine();
                        if (!admin.CheckPassword(confirmPassword))
                        {
                            throw new Exception("Incorrect password");

                        }

                        admin.RemoveUser(allUsers, admin, admins, removeBy);
                        Console.WriteLine($"Successfully removed {removeBy}");
                        Console.ReadLine();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        continue;
                    }

                }
                else if (option == "7")
                {
                    Console.Clear();
                    Console.WriteLine($"Goobye {admin.FirstName}");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option.");
                    Console.ReadLine();
                    continue;
                }
            }
        }

        public static void TrainerOptions(Trainer trainer, List<Student> students)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {trainer.FirstName}");
                Console.WriteLine("Select option : \n1.)See all students\n2.)Search students\n3.)See all subjects\n4.)Logout");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.Clear();
                    Console.Write("List of all students");
                    trainer.PrintStudents(students);
                    Console.ReadLine();
                    continue;
                }
                else if (option == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Search students;");
                    string searchTerm = Console.ReadLine();
                    Console.Clear();
                    trainer.PrintStudents(students, searchTerm);
                    Console.ReadLine();
                    continue;
                }
                else if (option == "3")
                {
                    Console.Clear();
                    trainer.PrintSubjects();
                    Console.ReadLine();
                    continue;
                }
                else if (option == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Goodbye");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option.");
                    Console.ReadLine();
                    break;
                }
            }
        }
        public static void StudentOptions(Student student)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {student.FirstName}");
                Console.WriteLine("Select option :\n1.)Check currect subject\n2.)Check grades\n3.)Logout");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.Clear();
                    if (student.CurrentSubject == 0)
                    {
                        Console.WriteLine("You do not attend any class at the moment");
                        Console.ReadLine();
                        continue;
                    }
                    Console.WriteLine($"Subject in progress : {student.CurrentSubject}");
                    Console.ReadLine();
                    continue;
                }
                else if (option == "2")
                {
                    Console.Clear();
                    student.GetGrades();
                    Console.ReadLine();
                    continue;
                }
                else if (option == "3")
                {
                    Console.Clear();
                    Console.WriteLine($"Goodbye {student.FirstName}");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option");
                    Console.ReadLine();
                    continue;
                }
            }
        }

        public static void UI(List<User> allUsers, List<Admin> admins, List<Trainer> trainers, List<Student> students)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Login as : \n1.)Admin\n2.)Trainer\n3.)Student\n4.)Exit");
                string loginOption = Console.ReadLine();
                if (loginOption == "1")
                {
                    Admin admin = HandleLogIn(admins);
                    if (admin == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect username/email or password");
                        Console.ReadLine();
                        continue;
                    }
                    AdminOptions(admin, allUsers, admins, trainers, students);
                }
                else if (loginOption == "2")
                {
                    Trainer trainer = HandleLogIn(trainers);
                    if (trainer == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect username/email or password");
                        Console.ReadLine();
                        continue;
                    }
                    TrainerOptions(trainer, students);
                }
                else if (loginOption == "3")
                {
                    Student student = HandleLogIn(students);
                    if (student == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect username/email or password");
                        Console.ReadLine();
                        continue;
                    }
                    StudentOptions(student);
                }
                else if (loginOption == "4")
                {
                    Console.WriteLine("Goobye.");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option");
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}