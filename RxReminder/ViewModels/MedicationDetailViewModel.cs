using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RxReminder.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RxReminder.ViewModels
{
    public partial class MedicationDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Medication medication;

        private ObservableCollection<Medication> Medications { get; }

        public MedicationDetailViewModel(Medication medication, ObservableCollection<Medication> medications)
        {
            Medication = medication;
            Medications = medications;
        }

        [RelayCommand]
        private async Task SaveMedicationAsync()
        {
            // Here you would normally save changes to the database

            // Notify CollectionView about the change
            var index = Medications.IndexOf(Medication);
            Medications.RemoveAt(index);
            Medications.Insert(index, Medication);

            // Navigate back to MedicationListView
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task DeleteMedicationAsync()
        {
            Medications.Remove(Medication);
            // Here you would normally delete the medication from the database
            // Navigate back to MedicationListView
            await Shell.Current.GoToAsync("..");
        }
    }
}
