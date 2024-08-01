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
            }
        }

        [RelayCommand]
        private async Task SaveMedicationAsync()
        {
            if (IsEditing)
            {
                ExistingMedication.Name = Name;
                ExistingMedication.Dosage = Dosage;
                ExistingMedication.Notes = Notes;
                ExistingMedication.TotalDoses = TotalDoses;
                ExistingMedication.RefillThreshold = RefillThreshold;
                ExistingMedication.RxNumber = RxNumber;

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
                    RxNumber = RxNumber
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
