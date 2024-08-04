using Microsoft.Maui.Controls;
using RxReminder.ViewModels;
using RxReminder.Models;
using System.Collections.Generic;

namespace RxReminder.Views
{
    public partial class MedicationListView : ContentPage
    {
        public MedicationListView()
        {
            InitializeComponent();
            BindingContext = new MedicationListViewModel();
        }

        //private async void OnMedicationSelected(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.CurrentSelection.Count > 0)
        //    {
        //        var selectedMedication = e.CurrentSelection[0] as Medication;
        //        var viewModel = BindingContext as MedicationListViewModel;
        //        await Shell.Current.GoToAsync(nameof(MedicationInputForm), new Dictionary<string, object>
        //        {
        //            { "Medication", selectedMedication },
        //            { "Medications", viewModel.Medications }
        //        });

        //        // Reset the selected item
        //        ((CollectionView)sender).SelectedItem = null;
        //    }
        //}
    }
}
