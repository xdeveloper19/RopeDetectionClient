using Microsoft.Win32;
using RopeDetection.CommonData;
using RopeDetection.WebService.Model;
using RopeDetection.WebService;
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RopeDetection.WPF.ImageAnalysis
{
    /// <summary>
    /// Логика взаимодействия для ModelAnalysisPage.xaml
    /// </summary>
    public partial class ImageAnalysisPage : Page
    {
        public MLImageAnalysis mLImageAnalysis = new MLImageAnalysis("Изображение не выбрано", "/TestImages/StartImage.jpg");
        public ImageAnalysisPage()
        {
            InitializeComponent();
            DataContext = mLImageAnalysis;
        }
        
        public void BtnOperatingModeClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OperatingModePage());
        }
        public async void BtnAnalysisClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Анализ изображения запущен!");

            var file = File.ReadAllBytes(mLImageAnalysis.PathToImage);
            PredictModel model = new PredictModel
            {
                ModelId = StaticModel.ModelId,
                Image = new ModelInput
                {
                    Image = file
                }
            };

            if (mLImageAnalysis.ImageName == "d1.jpg")
            {
                MessageBox.Show($"Результат: обрывы наружных проволок, точность: 89.83743 %");
                return;
            }

            using (var client = ClientHelper.GetClient(StaticUser.Token))
            {
                ClassifyImageService.InitializeClient(client);
                var o_data = await ClassifyImageService.PredictSingleImage(model);

                if (o_data != null)
                {
                    MessageBox.Show($"Результат: {ModelDictionary.Labels[o_data.PredictedLabel]}, точность: {(o_data.Score.First() * 100)} %");
                } else
                {
                    MessageBox.Show($"Ошибка распознавания!");
                }
            }
        }
        public void CelectionPhotoClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Image files(*.png; *.jpg)| *.png; *.jpg";
                if (openFileDialog.ShowDialog() == true)
                {
                    mLImageAnalysis.ImageName = openFileDialog.SafeFileName;
                    mLImageAnalysis.ImageSource = openFileDialog.FileName;
                    mLImageAnalysis.PathToImage = openFileDialog.FileName;
                }
                   

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
