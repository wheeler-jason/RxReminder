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

        public ObservableCollection<Medication> Medications { get; }

        public MedicationInputFormViewModel(ObservableCollection<Medication> medications)
        {
            Medications = medications;
        }

        [RelayCommand]
        private async Task SaveMedicationAsync()
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

            // Navigate back to MedicationListView
            await Shell.Current.GoToAsync("..");
        }
    }
}
