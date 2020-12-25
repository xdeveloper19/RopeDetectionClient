using RopeDetection.CommonData.ViewModels.UserViewModel;
using RopeDetection.WPF.CreatingTrainingModel;
using RopeDetection.WPF.HomeRegistrationLogin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RopeDetection.WPF.HomeRegistrationLogin
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        MLRegistrationPage registrationPageModel = new MLRegistrationPage();
        public RegistrationPage()
        {
            InitializeComponent();
            DataContext = registrationPageModel;
        }

        public void Password_ChangeText(object sender, RoutedEventArgs e)
        {
            var item = sender as PasswordBox;
            registrationPageModel.Password = item.Password;

        }
        public void Password_ChangeTextRepeat(object sender, RoutedEventArgs e)
        {
            var item = sender as PasswordBox;
            string _passwordrepeat = item.Password;
        }
        public void BtnHomeClick(object sender, RoutedEventArgs e)
        {
            HomePage home = new HomePage();
            this.NavigationService.Navigate(home);
        }
        
        public async void BtnRegistrationClick(object sender, RoutedEventArgs e)
        {
            UserModel _user = new UserModel();
            _user.UserFIO = registrationPageModel.FullName;
            _user.Email = registrationPageModel.Email;
            _user.Password = registrationPageModel.Password;
            var message = await RegistrationAuthMethods.RegisterUser(_user);

            //if (string.IsNullOrEmpty(registrationPageModel.Login) || string.IsNullOrEmpty(registrationPageModel.Password) ||
            //    string.IsNullOrEmpty(registrationPageModel.FullName) || string.IsNullOrEmpty(registrationPageModel.Email) ||
            //    string.IsNullOrEmpty(registrationPageModel.RepeatPassword))
            //{
            //    MessageBox.Show("Вы заполнили не все данные !");
            //}
            //else
            //{
            //    if (registrationPageModel.Password != registrationPageModel.RepeatPassword)
            //    {
            //        MessageBox.Show("Пароли не совпадают !");
            //    }
            //    else
            //    {

            //    }
            //}
        }
    }
}
