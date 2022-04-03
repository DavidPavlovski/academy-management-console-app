using System;

namespace Models
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Password { get; private set; }

        public User(string userName, string firstName, string lastName, string email, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("User name is requiered");

            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException("First Name is requiered");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException("Last Name is requiered");
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Email is requiered");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password is requiered");
            }
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public bool CheckPassword(string password)
        {
            if (password == Password)
            {
                return true;
            }
            return false;
        }
    }
}
