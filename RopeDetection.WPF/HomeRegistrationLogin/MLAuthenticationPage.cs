using RopeDetection.WPF;
using RopeDetection.WPF.HomeRegistrationLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace RopeDetection.WPF.HomeRegistrationLogin
{
    public class MLAuthenticationPage  : ObservableObject
    {
        private string _userlogin;
        private string _userpassword;

        public string UserLogin
        {
            get
            {
                if (string.IsNullOrEmpty(_userlogin))
                    return "";
                return _userlogin;
            }
            set
            {
                _userlogin = value;
                OnPropertyChanged("userlogin");
            }
        }
        public string UserPassword
        {
            get
            {
                if (string.IsNullOrEmpty(_userpassword))
                    return "";
                return _userpassword;
            }
            set
            {
                _userpassword = value;
                OnPropertyChanged("userpassword");
            }
        }
    }
}
