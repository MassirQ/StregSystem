using System;

namespace StregSystem2.Exceptions
{
    public class UserNotFoundException:Exception
    {
        private string _userName;

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public UserNotFoundException(string username) : base("User with username " + username + " was not found.")
        {
            _userName = username;
        }
        

    }
}