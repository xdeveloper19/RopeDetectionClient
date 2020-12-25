using RopeDetection.WPF;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace RopeDetection.WPF.HomeRegistrationLogin
{
    public class MLRegistrationPage : ObservableObject
    {
        private string _fullname;
        private string _email;
        private string _login;
        private string _password;
        private string _repeatpassword;

        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(_fullname))
                    return "";
                return _fullname;
            }
            set
            {
                _fullname = value;
                OnPropertyChanged("fullname");
            }
        }
        public string Email
        {
            get
            {
                if (string.IsNullOrEmpty(_email))
                    return "";
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("email");
            }
        }
        public string Login
        {
            get
            {
                if (string.IsNullOrEmpty(_login))
                    return "";
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged("login");
            }
        }
        public string Password
        {
            get
            {
                if (string.IsNullOrEmpty(_password))
                    return "";
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("password");
            }
        }
        public string RepeatPassword
        {
            get
            {
                if (string.IsNullOrEmpty(_repeatpassword))
                    return "";
                return _repeatpassword;
            }
            set
            {
                _repeatpassword = value;
                OnPropertyChanged("repeatpassword");
            }
        }
    }
}
