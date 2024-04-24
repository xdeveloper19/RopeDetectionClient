using RopeDetection.WPF.CreatingTrainingModel;
using RopeDetection.WPF.StaticClass;
using System.Windows;
using System.Windows.Controls;

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
            var typeName = TrainingScenarioList.SelectionBoxItem.ToString();
            var InfoMessage = await ModelCreationMethods.CreateModel(_mLScenarioSelection.NameModel, typeName);
            MessageBox.Show(InfoMessage);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var typeName = TrainingScenarioList.SelectionBoxItem.ToString();

            if (typeName == "Распознавание объектов")
            {
                StaticModel.ModelType = CommonData.ModelEnums.ModelType.ObjectDetection;
                //var path = "C:\\Users\\Daria\\source\\repos\\RopeDetectionNetwork\\scripts\\get_model.m";
                //var pi = new ProcessStartInfo(path)
                //{
                //    Arguments = Path.GetFileName(path),
                //    UseShellExecute = true,
                //    WorkingDirectory = Path.GetDirectoryName(path),
                //    FileName = "C:\\Program Files\\MATLAB\\R2018b\\bin\\matlab.exe",
                //    Verb = "OPEN"
                //};
                //Process.Start(pi);
                //MessageBox.Show("OK");
                //return;
            }
        }
    }
}
