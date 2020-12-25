using RopeDetection.WPF.StaticClass;
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
                mLModelCreationSteps.StepDescription = "Провести обучение";
                ModelCreationFrame.NavigationService.Navigate(new StartTeachingPage());
            }
            else if (mLModelCreationSteps.StepName == "3")
            {
                mLModelCreationSteps.StepName = "4";
                mLModelCreationSteps.StepDescription = "Результат обучения";
                mLModelCreationSteps.ButtonText = "Готово";
                ModelCreationFrame.NavigationService.Navigate(new ShowTeachingResultPage());               
            }
        }
    }
}
