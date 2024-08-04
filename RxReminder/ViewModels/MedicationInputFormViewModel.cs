using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RxReminder.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RxReminder.ViewModels
{
    public partial class MedicationInputFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string dosage;

        [ObservableProperty]
        private string notes;

        [ObservableProperty]
        private int totalDoses;

        [ObservableProperty]
        private int refillThreshold;

        [ObservableProperty]
        private string rxNumber;

        [ObservableProperty]
        private DateTime firstNotification;

        [ObservableProperty]
        private bool isDays = true;

        [ObservableProperty]
        private bool isHours;

        [ObservableProperty]
        private bool isMinutes;

        [ObservableProperty]
        private int repeatAmount;

        [ObservableProperty]
        private string pageTitle;

        [ObservableProperty]
        private bool isEditing;

        public ObservableCollection<Medication> Medications { get; set; }

        public Medication ExistingMedication { get; private set; }

        public MedicationInputFormViewModel()
        {
        }

        public void Initialize(ObservableCollection<Medication> medications, Medication medication)
        {
            Medications = medications;
            ExistingMedication = medication;

            if (medication != null)
            {
                IsEditing = true;
                PageTitle = "Medication Details";
                Name = medication.Name;
                Dosage = medication.Dosage;
                Notes = medication.Notes;
                TotalDoses = medication.TotalDoses;
                RefillThreshold = medication.RefillThreshold;
                RxNumber = medication.RxNumber;
                FirstNotification = medication.FirstNotification;
                RepeatAmount = (int)medication.RepeatInterval.TotalDays; // Assuming default is days
                IsDays = true; // Default to days for existing medication
            }
            else
            {
                IsEditing = false;
                PageTitle = "Add New Medication";
                Name = string.Empty;
                Dosage = string.Empty;
                Notes = string.Empty;
                TotalDoses = 0;
                RefillThreshold = 0;
                RxNumber = string.Empty;
                FirstNotification = DateTime.Now;
                RepeatAmount = 1; // Default repeat amount
                IsDays = true; // Default to days
            }
        }

        [RelayCommand]
        private async Task SaveMedicationAsync()
        {
            TimeSpan repeatInterval;

            if (IsDays)
            {
                repeatInterval = TimeSpan.FromDays(RepeatAmount);
            }
            else if (IsHours)
            {
                repeatInterval = TimeSpan.FromHours(RepeatAmount);
            }
            else // IsMinutes
            {
                repeatInterval = TimeSpan.FromMinutes(RepeatAmount);
            }


            if (IsEditing)
            {
                ExistingMedication.Name = Name;
                ExistingMedication.Dosage = Dosage;
                ExistingMedication.Notes = Notes;
                ExistingMedication.TotalDoses = TotalDoses;
                ExistingMedication.RefillThreshold = RefillThreshold;
                ExistingMedication.RxNumber = RxNumber;
                ExistingMedication.FirstNotification = FirstNotification;
                ExistingMedication.RepeatInterval = repeatInterval;

                var index = Medications.IndexOf(ExistingMedication);
                if (index != -1)
                {
                    Medications[index] = ExistingMedication;
                }
            }
            else
            {
                var newMedication = new Medication
                {
                    Name = Name,
                    Dosage = Dosage,
                    Notes = Notes,
                    TotalDoses = TotalDoses,
                    RefillThreshold = RefillThreshold,
                    RxNumber = RxNumber,
                    FirstNotification = FirstNotification,
                    RepeatInterval = repeatInterval
                };

                Medications.Add(newMedication);
            }

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task DeleteMedicationAsync()
        {
            if (IsEditing && ExistingMedication != null)
            {
                Medications.Remove(ExistingMedication);
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
