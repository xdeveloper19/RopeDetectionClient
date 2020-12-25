using System;
using System.Collections.Generic;
using System.Text;

namespace RopeDetection.WPF.CreatingTrainingModel
{
    public class MLListOfModels : ObservableObject
    {
        public string NameModel { get; set; }
        private string _titleName { get; set; }

        public string TitleName
        {
            get
            {
                if (string.IsNullOrEmpty(_titleName))
                    return "";
                return _titleName;
            }
            set
            {
                _titleName = value;
                OnPropertyChanged("titleName");
            }
        }
        public MLListOfModels(string NameModel)
        {
            this.NameModel = NameModel;
        }
        public MLListOfModels()
        {
            this.NameModel = "";
        }
    }
}
