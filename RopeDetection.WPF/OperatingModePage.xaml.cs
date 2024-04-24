using RopeDetection.WPF.CreatingTrainingModel;
using RopeDetection.WPF.HomeRegistrationLogin;
using System.Windows;
using System.Windows.Controls;

namespace RopeDetection.WPF
{
    /// <summary>
    /// Логика взаимодействия для OperatingModePage.xaml
    /// </summary>
    public partial class OperatingModePage : Page
    {       
        public OperatingModePage()
        {
            InitializeComponent();
        }

        private void BtnLearningClick(object sender, RoutedEventArgs e)
        {
            ListOfModels listOfModels = new ListOfModels(false);
            this.NavigationService.Navigate(listOfModels);
        }
        
        private void BtnExitClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult boxResult = MessageBox.Show("Вы действительно хотите покинуть свой профиль?", "Выход", 
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch(boxResult)
            {
                case MessageBoxResult.Yes:
                    LeaveProfileMethod();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private async void LeaveProfileMethod()
        {
            var messge = await RegistrationAuthMethods.ExitMethod();
            MessageBox.Show(messge);
            OperatingModePage operating = new OperatingModePage();
            this.NavigationService.Navigate(operating);
        }     

        private void BtnAnalysisClick(object sender, RoutedEventArgs e)
        {
            ListOfModels listOfModels = new ListOfModels(true);
            this.NavigationService.Navigate(listOfModels);
            //ListItems listItems = new ListItems();
            //this.NavigationService.Navigate(listItems);
        }
    }
}
