using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;

namespace RxReminder.Models
{
    public class Medication : ObservableObject
    {
        private int _id;
        private string _name;
        private string _dosage;
        private string _notes;
        private int _totalDoses;
        private int _refillThreshold;
        private string _rxNumber;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Dosage
        {
            get => _dosage;
            set => SetProperty(ref _dosage, value);
        }

        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        public int TotalDoses
        {
            get => _totalDoses;
            set => SetProperty(ref _totalDoses, value);
        }

        public int RefillThreshold
        {
            get => _refillThreshold;
            set => SetProperty(ref _refillThreshold, value);
        }

        public string RxNumber
        {
            get => _rxNumber;
            set => SetProperty(ref _rxNumber, value);
        }
    }
}
