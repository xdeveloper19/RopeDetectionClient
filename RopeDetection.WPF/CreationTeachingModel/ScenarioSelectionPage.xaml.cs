using RopeDetection.WPF.CreatingTrainingModel;
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

namespace RopeDetection.WPF.CreationTeachingModel
{
    /// <summary>
    /// Логика взаимодействия для NameModelPage.xaml
    /// </summary>
    public partial class ScenarioSelectionPage : Page
    {
        public MLScenarioSelection _mLScenarioSelection = new MLScenarioSelection();
        public ScenarioSelectionPage()
        {
            InitializeComponent();
            DataContext = _mLScenarioSelection;
        }

        public async void BtnModelCreationClick(object sender, RoutedEventArgs e)
        {
            var typeName = TrainingScenarioList.SelectedItem as string;
            var InfoMessage = await ModelCreationMethods.CreateModel(_mLScenarioSelection.NameModel, typeName);
            MessageBox.Show(InfoMessage);
        }


    }
}
