using RopeDetection.WPF;
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
    public partial class AuthenticationPage : Page
    {
        MLAuthenticationPage _loginPageModel = new MLAuthenticationPage();
        public AuthenticationPage()
        {
            InitializeComponent();
            DataContext = _loginPageModel;
        }

        public async void BtnAuthClick(object sendr, RoutedEventArgs e)
        {
            var message = await RegistrationAuthMethods.AuthMethod(_loginPageModel.UserLogin, _loginPageModel.UserPassword);
            MessageBox.Show(message);
            OperatingModePage operating = new OperatingModePage();
            this.NavigationService.Navigate(operating);
        }

        public void BtnHomeClick(object sendr, RoutedEventArgs e)
        {
            HomePage home = new HomePage();
            this.NavigationService.Navigate(home);
            //var messge = await RegistrationAuthMethods.qqq();
            //MessageBox.Show(messge);
        }


        public void Password_ChangeText(object sender, RoutedEventArgs e)
        {
            var p = sender as PasswordBox;
            _loginPageModel.UserPassword = p.Password;
        }

        //private void BtnRegistrationClick(object sender, RoutedEventArgs e)
        //{
        //    //try
        //    //{

        //    //    //using (var client = ClientHelper.GetClient(_loginPageModel.UserLogin, _loginPageModel.UserPassword))
        //    //    //{
        //    //    //    AuthService.InitializeClient(client);
        //    //    //    var o_data = await AuthService.Login(_loginPageModel.UserLogin, _loginPageModel.UserPassword);

        //    //    //    if (o_data.Result == Result.OK)
        //    //    //    {

        //    //    //    }
        //    //    //    else
        //    //    //    {
        //    //    //        MessageBox.Show(o_data.ErrorInfo);
        //    //    //    }
        //    //    //}

        //    //    //using (var client = ClientHelper.GetClient(CrossSettings.Current.GetValueOrDefault("token", "")))
        //    //    //{
        //    //    //    AuthService.InitializeClient(client);
        //    //    //    await AuthService.Login(CrossSettings.Current.GetValueOrDefault("token", ""));
        //    //    //}
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show("Ошибка: " + ex.Message);
        //    //}
        //}
    }
}
