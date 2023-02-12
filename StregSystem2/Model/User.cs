using System;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace StregSystem2.Model
{
    public delegate void UserBalanceNotification(User user, decimal balance);
    public class User: IComparable<User>
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private decimal _balance;

        public User(int id, string firstName, string lastName, string userName, string email, decimal balance)
        {
            _id = id;
            _firstName = firstName;
            if (firstName == null || firstName.Trim().Length < 1)
            {
                throw new ArgumentNullException();
            }

            _lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            if (lastName == null || lastName.Trim().Length < 1)
            {
                throw new ArgumentNullException();
            }

            _userName = userName;
            if (!Regex.IsMatch(userName, @"^[a-z0-9_]+$"))
            {
                throw new ArgumentException("Your username may only contain [0-9], [a-z] and '_' ");
            }

            _email = email;
            if (!Regex.IsMatch(email,
                    @"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$"))
            {
                throw new ArgumentException("Your email is not valid, a valid email is: example@domain.dk ");
            }

            _balance = balance;
            
        }

        public int Id
        {
            get => _id;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public decimal Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public bool active { get; set; }

        public override bool Equals(object obj)
        {
            User user = obj as User;
            return user != null &&
                   Id == user.Id &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   UserName == user.UserName &&
                   Email == user.Email &&
                   Balance == user.Balance;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Email})";
        }

        public int CompareTo(User other)
        {
            return Id.CompareTo(other.Id);
        }
        
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + FirstName.GetHashCode();
            hash = hash * 23 + LastName.GetHashCode();
            return hash;
        }

        public static void NotifyUser(User user, decimal balance)
        {
            if (balance < 50)
                Console.WriteLine($"Advarsel: {user.FirstName}'s saldo er under 50 kr.");
        }

        
    }
}