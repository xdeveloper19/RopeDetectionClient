using System;
using System.Collections.Generic;
using System.Text;

namespace RopeDetection.WPF.CreationTeachingModel
{
    public class MLModelCreationSteps : ObservableObject
    {
        private string _stepName;
        private string _stepDescription;
        private string _buttonText;

        public string ButtonText
        {
            get
            {
                if (string.IsNullOrEmpty(_buttonText))
                    return "";
                return _buttonText;
            }
            set
            {
                _buttonText = value;
                OnPropertyChanged("buttonText");
            }
        }
        public string StepName
        {
            get
            {
                if (string.IsNullOrEmpty(_stepName))
                    return "";
                return _stepName;
            }
            set
            {
                _stepName = value;
                OnPropertyChanged("stepName");
            }
        }
        public string StepDescription
        {
            get
            {
                if (string.IsNullOrEmpty(_stepDescription))
                    return "";
                return _stepDescription;
            }
            set
            {
                _stepDescription = value;
                OnPropertyChanged("stepsDescription");
            }
        }
    }
}
