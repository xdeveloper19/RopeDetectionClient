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
    /// Логика взаимодействия для ShowTeachingResult.xaml
    /// </summary>
    public partial class ShowTeachingResultPage : Page
    {
        public MLShowTreaningResult mLShowTreaningResult = new MLShowTreaningResult();
        string _colorTrue = "нет ошибок - #00FF7F. ошибка - #FA8072";
        public ShowTeachingResultPage()
        {
            InitializeComponent();
            mLShowTreaningResult.EndDate = "23:32 22/12/2020";
            mLShowTreaningResult.TeachingAccuracy = "99.76%";
            mLShowTreaningResult.StartDate = "22:09 22/12/2020";
            mLShowTreaningResult.TeachingResult = "Модель «" + StaticModel.NameModel + "» была успешно обучена";
            DataContext = mLShowTreaningResult;
        }
    }
}
