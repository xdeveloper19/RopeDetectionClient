using System;
using System.Collections.Generic;
using System.Text;

namespace RopeDetection.WPF.CreationTeachingModel
{
    public class MLShowTreaningResult : ObservableObject
    {
        private string _teachingResult;
        private string _teachingAccuracy;
        private string _startDate;
        private string _endDate;

        public string TeachingResult
        {
            get
            {
                if (String.IsNullOrEmpty(_teachingResult))
                    return "";
                return _teachingResult;
            }
            set
            {
                _teachingResult = value;
                OnPropertyChanged("teachingResult");
            }
        }
        public string TeachingAccuracy
        {
            get
            {
                if (String.IsNullOrEmpty(_teachingAccuracy))
                    return "";
                return _teachingAccuracy;
            }
            set
            {
                _teachingAccuracy = value;
                OnPropertyChanged("teachingAccuracy");
            }
        }
        public string StartDate
        {
            get
            {
                if (String.IsNullOrEmpty(_startDate))
                    return "";
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged("startDate");
            }
        }
        public string EndDate
        {
            get
            {
                if (String.IsNullOrEmpty(_endDate))
                    return "";
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged("endDate");
            }
        }
    }
}
