using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace RopeDetection.WPF.CreatingTrainingModel
{
    public class MLAddDate : ObservableObject
    {
        //private string _nameModel;
        private string _typeDefect;
        private string _numberSelectedPhotos;

        //public string NameModel
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_nameModel))
        //            return "";
        //        return _nameModel;
        //    }
        //    set
        //    {
        //        _nameModel = value;
        //        OnPropertyChanged("nameModel");
        //    }
        //}
        public string TypeDefect
        {
            get
            {
                if (string.IsNullOrEmpty(_typeDefect))
                    return "";
                return _typeDefect;
            }
            set
            {
                _typeDefect = value;
                OnPropertyChanged("nameModelList");
            }
        }
        public string NumberSelectedPhotos
        {
            get
            {
                if (string.IsNullOrEmpty(_numberSelectedPhotos))
                    return "";
                return _numberSelectedPhotos;
            }
            set
            {
                _numberSelectedPhotos = value;
                OnPropertyChanged("numberSelectedPhotos");
            }
        }     
      
        public List<BitmapImage> GetListOfImages(string[] FileNames, List<BitmapImage> bitmapImages)
        {
            foreach (var filename in FileNames)
            {
                BitmapImage bm1 = new BitmapImage();
                bm1.BeginInit();
                bm1.UriSource = new Uri(filename, UriKind.RelativeOrAbsolute);
                bm1.EndInit();
                bitmapImages.Add(bm1);
            }

            return bitmapImages;
        }
    }
}
