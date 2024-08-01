using Microsoft.Maui.Controls;
using RxReminder.ViewModels;
using RxReminder.Models;
using System.Collections.ObjectModel;

namespace RxReminder.Views
{
    [QueryProperty(nameof(Medication), "Medication")]
    [QueryProperty(nameof(Medications), "Medications")]
    public partial class MedicationInputForm : ContentPage
    {
        public Medication Medication { get; set; }
        public ObservableCollection<Medication> Medications { get; set; }

        public MedicationInputForm()
        {
            InitializeComponent();
            BindingContext = new MedicationInputFormViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is MedicationInputFormViewModel viewModel)
            {
                viewModel.Initialize(Medications, Medication);
            }
        }
    }
}
