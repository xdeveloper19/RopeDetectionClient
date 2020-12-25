using Microsoft.Win32;
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
        public void BtnAnalysisClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Анализ изображения запущен !");
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
