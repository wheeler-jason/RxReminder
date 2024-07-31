using Microsoft.Maui.Controls;
using RxReminder.ViewModels;
using System.Collections.ObjectModel;
using RxReminder.Models;

namespace RxReminder.Views
{
    [QueryProperty(nameof(Medications), "Medications")]
    public partial class MedicationInputForm : ContentPage
    {
        public ObservableCollection<Medication> Medications { get; set; }

        public MedicationInputForm()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext == null)
            {
                BindingContext = new MedicationInputFormViewModel(Medications);
            }
        }
    }
}
