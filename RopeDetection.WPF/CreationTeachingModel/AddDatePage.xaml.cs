using Microsoft.Win32;
using RopeDetection.CommonData.ViewModels.LabelViewModel;
using RopeDetection.WPF.CreatingTrainingModel;
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
    /// Логика взаимодействия для ImagesDownload.xaml
    /// </summary>
    public partial class AddDatePage : Page
    {
        public MLAddDate imagePageModel = new MLAddDate();
        public string[] _fileNames { get; set; }
        private List<LabelModel> labels { get; set; }
        public AddDatePage()
        {
            InitializeComponent();
            labels = new List<LabelModel>();
            GetLabelsMethod();

            StaticModel.IsAllDataEntered = false;
            imagePageModel.NumberSelectedPhotos = "0";
            imagePageModel.TypeDefect = "Не выбран";
            DownloadStatusBar.Visibility = Visibility.Hidden;
            DataContext = imagePageModel;
        }

        private async void GetLabelsMethod()
        {
            labels = await ModelCreationMethods.GetLabels();
            if (labels.Count > 0)
            {
                LabelsList.ItemsSource = labels;
            }
            else
            {
                MessageBox.Show("Произошла какая-то ошибка ! Не получилось загрузить список дефектов: ");
            }
        }

        private void BtnSelectPhotoClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Image files(*.png; *.jpg)| *.png; *.jpg";
                if (openFileDialog.ShowDialog() == true)
                    _fileNames = openFileDialog.FileNames;

                imagePageModel.NumberSelectedPhotos = _fileNames.Length.ToString();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
       }
        private async void BtnDownloadClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Загрузка файлов началась. Вам придёт оповещение об окончании загрузки.", "Загрузка", MessageBoxButton.OK);
            DownloadStatusBar.Visibility = Visibility.Visible;

            var selectedItem = LabelsList.SelectedItem as LabelModel;
            var typeId = selectedItem.Id;
            StaticModel.TypeId = selectedItem.Id;
            var message = await ModelCreationMethods.UploadTrainingFiles(_fileNames, typeId);
            MessageBox.Show(message);
            DownloadStatusBar.Visibility = Visibility.Hidden;

            //MessageBoxResult boxResult = MessageBox.Show("Вы действительно хотите покинуть свой профиль?", "Загрузка", MessageBoxButton.OK);
            //switch (boxResult)
            //{
            //    case MessageBoxResult.OK:
            //        DownloadStatusBar.Visibility = Visibility.Hidden;
            //        break;
            //}
            //var message = await LabelModel(_loginPageModel.UserLogin, _loginPageModel.UserPassword);
            //MessageBox.Show(message);
        }
    }
}
