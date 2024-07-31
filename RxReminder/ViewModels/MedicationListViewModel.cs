using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using RxReminder.Models;
using RxReminder.Views;

namespace RxReminder.ViewModels
{
    public partial class MedicationListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Medication> medications;

        public MedicationListViewModel()
        {
            Medications = new ObservableCollection<Medication>();
        }

        [RelayCommand]
        private async Task AddNewMedicationAsync()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Medications", Medications }
            };
            await Shell.Current.GoToAsync(nameof(MedicationInputForm), navigationParameter);
        }
    }
}
