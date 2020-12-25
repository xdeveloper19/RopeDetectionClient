using System;
using System.Collections.Generic;
using System.Text;

namespace RopeDetection.WPF.ImageAnalysis
{
    public class MLImageAnalysis : ObservableObject
    {
        public MLImageAnalysis(string startValue, string imageSource)
        {
            this._imageName = startValue;
            this._pahtToImage = startValue;
            this._imageSource = imageSource;
        }
        private string _pahtToImage;
        private string _imageName;
        private string _imageSource;

        public string ImageSource
        {
            get
            {
                if (string.IsNullOrEmpty(_imageSource))
                    return "";
                return _imageSource;
            }
            set
            {
                _imageSource = value;
                OnPropertyChanged("imageSource");
            }
        }
        public string PathToImage
        {
            get
            {
                if (string.IsNullOrEmpty(_pahtToImage))
                    return "";
                return _pahtToImage;
            }
            set
            {
                _pahtToImage = value;
                OnPropertyChanged("pahtToImage");
            }
        }
        public string ImageName
        {
            get
            {
                if (string.IsNullOrEmpty(_imageName))
                    return "";
                return _imageName;
            }
            set
            {
                _imageName = value;
                OnPropertyChanged("imageName");
            }
        }
    }
}
