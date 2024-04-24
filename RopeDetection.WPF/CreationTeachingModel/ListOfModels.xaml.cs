using RopeDetection.CommonData.ViewModels.LabelViewModel;
using RopeDetection.WPF.CreationTeachingModel;
using RopeDetection.WPF.ImageAnalysis;
using RopeDetection.WPF.StaticClass;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RopeDetection.WPF.CreatingTrainingModel
{
    /// <summary>
    /// Логика взаимодействия для ListOfModels.xaml
    /// </summary>
    public partial class ListOfModels : Page
    {
        public List<ModelResponse> _listModels { get; set; }
        public MLListOfModels mLListOfModels = new MLListOfModels();
        private bool IsShowTrainedModels { get; set; }
        public ListOfModels(bool IsShowTrainedModels)
        {
            InitializeComponent();
            GetModelsMethod();
            this.IsShowTrainedModels = IsShowTrainedModels;

            if(IsShowTrainedModels)
                mLListOfModels.TitleName = "-Список обученных моделей-";
            else
                mLListOfModels.TitleName = "-Список не обученных моделей-";
            DataContext = mLListOfModels;
            //GetInfoImages();
            // AddDoubleClickEventStyle(ListOfModels, new MouseButtonEventHandler(listView1_MouseDoubleClick));

        }

        private async void GetModelsMethod()
        {
            _listModels = await ModelCreationMethods.GetModels(IsShowTrainedModels);
            if (_listModels.Count > 0)
                ListModels.ItemsSource = _listModels;
        }

        //private List<MLListOfModels> GetInfoImages()
        //{
        //    return new List<MLListOfModels>()
        //    {
        //        new MLListOfModels("Модель№1"),
        //        new MLListOfModels("Модель№2"),
        //        new MLListOfModels("Модель№3"),
        //        new MLListOfModels("Модель№4"),
        //    };

        //}

        private void BtnModelCreationClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ModelCreationSteps());
        }
        private void BtnDoneClick(object sender, RoutedEventArgs e)
        {
            if (ListModels.SelectedItems.Count == 0)
                MessageBox.Show("Необходимо выбрать модель !");
            else
            {
                var SelectedModel = ListModels.SelectedItem as ModelResponse;
                if (IsShowTrainedModels)
                {
                    StaticModel.ModelId = SelectedModel.Id;
                    StaticModel.NameModel = SelectedModel.Name;
                    StaticModel.ModelType = SelectedModel.Type;
                    this.NavigationService.Navigate(new ImageAnalysisPage());
                }
                else
                {
                    StaticModel.ModelId = SelectedModel.Id;
                    StaticModel.NameModel = SelectedModel.Name;
                    AddDatePage operatingModePage = new AddDatePage();
                    this.NavigationService.Navigate(new ModelCreationSteps());
                }               
            }           
        }
    }
}
