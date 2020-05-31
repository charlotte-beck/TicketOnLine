using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Repositories.Data
{
    public class User
    {
        //public int UserId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Passwd { get; set; }
        //public bool IsAdmin { get; set; }
        //public bool IsActive { get; set; }

        private int _userId;
        private string _firstName, _lastName, _email, _passwd, _token;
        private bool _isAdmin, _isActive;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Passwd
        {
            get { return _passwd; }
            set { _passwd = value; }
        }
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public User(int userId, string email, bool isAdmin, bool isActive)
        {
            UserId = userId;
            Email = email;
            IsAdmin = isAdmin;
            IsActive = isActive;
        }

        public User(int userId, string firstName, string lastName, string email, string passwd, bool isAdmin, bool isActive)
            : this (userId, email, isAdmin, isActive)
        {
            FirstName = firstName;
            LastName = lastName;           
            Passwd = passwd;
        }
    }
}
