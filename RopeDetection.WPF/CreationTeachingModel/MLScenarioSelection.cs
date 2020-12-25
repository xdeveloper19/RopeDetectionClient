using System;
using System.Collections.Generic;
using System.Text;

namespace RopeDetection.WPF.CreationTeachingModel
{
    public class MLScenarioSelection : ObservableObject
    {
        private string _nameModel;

        public string NameModel
        {
            get
            {
                if (string.IsNullOrEmpty(_nameModel))
                    return "";
                return _nameModel;
            }
            set
            {
                _nameModel = value;
                OnPropertyChanged("nameModel");
            }
        }
    }
}
