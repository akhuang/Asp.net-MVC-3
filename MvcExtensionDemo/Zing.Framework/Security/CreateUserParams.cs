using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.Security
{
    public class CreateUserParams
    {
        private readonly string _normalizedUserName;
        private readonly string _username;
        private readonly string _password;
        private readonly string _email;
        private readonly string _passwordQuestion;
        private readonly string _passwordAnswer;
        private readonly bool _isApproved;

        public CreateUserParams(string normalizedUserName, string username, string password, string email)
        {
            _normalizedUserName = normalizedUserName;
            _username = username;
            _password = password;
            _email = email;
        }

        public string NormalizedUserName
        {
            get
            {
                return _normalizedUserName;
            }
        }

        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string PasswordQuestion
        {
            get { return _passwordQuestion; }
        }

        public string PasswordAnswer
        {
            get { return _passwordAnswer; }
        }

        public bool IsApproved
        {
            get { return _isApproved; }
        }
    }
}
