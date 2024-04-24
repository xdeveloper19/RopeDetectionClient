using RopeDetection.WPF.StaticClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для ModelCreationSteps.xaml
    /// </summary>
    public partial class ModelCreationSteps : Page
    {
        public MLModelCreationSteps mLModelCreationSteps = new MLModelCreationSteps();
        public ModelCreationSteps()
        {
            InitializeComponent();
            mLModelCreationSteps.ButtonText = "Далее";
            mLModelCreationSteps.StepName = "1";
            mLModelCreationSteps.StepDescription = "Выбор сценария обучения";
            DataContext = mLModelCreationSteps;
            ModelCreationFrame.NavigationService.Navigate(new ScenarioSelectionPage());
        }

        public ModelCreationSteps(string g)
        {
            ModelCreationFrame.NavigationService.Navigate(new AddDatePage());
        }

        private void BtnContinueClick(object sender, RoutedEventArgs e)
        {

            if (mLModelCreationSteps.StepName == "1")
            {
                if(StaticModel.IsAllDataEntered != true)
                {
                    MessageBox.Show("Вы заполнили не все данные !");
                }
                else
                {
                    mLModelCreationSteps.StepName = "2";
                    mLModelCreationSteps.StepDescription = "Добавление данных";
                    ModelCreationFrame.NavigationService.Navigate(new AddDatePage());
                }               
            }
            else if (mLModelCreationSteps.StepName == "2")
            {
                mLModelCreationSteps.StepName = "3";
                if (StaticModel.ModelType == CommonData.ModelEnums.ModelType.ObjectDetection)
                {
                    mLModelCreationSteps.StepDescription = "Провести разметку изображений";
                    ModelCreationFrame.NavigationService.Navigate(new StartLabelingPage());
                } 
                else
                {

                    mLModelCreationSteps.StepDescription = "Провести обучение";
                    ModelCreationFrame.NavigationService.Navigate(new StartTeachingPage());
                }
            }
            else if (mLModelCreationSteps.StepName == "3")
            {
                mLModelCreationSteps.StepName = "4";
                if (StaticModel.ModelType == CommonData.ModelEnums.ModelType.ObjectDetection)
                {
                    var path = "C:\\Users\\Daria\\source\\repos\\RopeDetectionNetwork\\scripts\\save_label.m";
                    var pi = new ProcessStartInfo(path)
                    {
                        Arguments = System.IO.Path.GetFileName(path),
                        UseShellExecute = true,
                        WorkingDirectory = System.IO.Path.GetDirectoryName(path),
                        FileName = "C:\\Program Files\\MATLAB\\R2018b\\bin\\matlab.exe",
                        Verb = "OPEN"
                    };
                    Process.Start(pi);
                    mLModelCreationSteps.StepDescription = "Провести обучение";
                    ModelCreationFrame.NavigationService.Navigate(new StartTeachingPage());
                } 
                else
                {
                    mLModelCreationSteps.StepDescription = "Результат обучения";
                    mLModelCreationSteps.ButtonText = "Готово";
                    ModelCreationFrame.NavigationService.Navigate(new ShowTeachingResultPage());
                }             
            }
            else if (mLModelCreationSteps.StepName == "4")
            {
                mLModelCreationSteps.StepName = "5";
                if (StaticModel.ModelType == CommonData.ModelEnums.ModelType.ObjectDetection)
                {
                    var path = "C:\\Users\\Daria\\source\\repos\\RopeDetectionNetwork\\scripts\\train_model.m";
                    var pi = new ProcessStartInfo(path)
                    {
                        Arguments = System.IO.Path.GetFileName(path),
                        UseShellExecute = true,
                        WorkingDirectory = System.IO.Path.GetDirectoryName(path),
                        FileName = "C:\\Program Files\\MATLAB\\R2018b\\bin\\matlab.exe",
                        Verb = "OPEN"
                    };
                    Process.Start(pi);
                }

                mLModelCreationSteps.StepDescription = "Результат обучения";
                mLModelCreationSteps.ButtonText = "Готово";
                ModelCreationFrame.NavigationService.Navigate(new ShowTeachingResultPage());
            }
        }
    }
}
