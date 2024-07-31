using Microsoft.Maui.Controls;
using RxReminder.ViewModels;
using RxReminder.Models;
using System.Collections.ObjectModel;

namespace RxReminder.Views;

[QueryProperty(nameof(Medication), "Medication")]
[QueryProperty(nameof(Medications), "Medications")]
public partial class MedicationDetailView : ContentPage
{
    public Medication Medication { get; set; }
    public ObservableCollection<Medication> Medications { get; set; }

    public MedicationDetailView()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext == null)
        {
            BindingContext = new MedicationDetailViewModel(Medication, Medications);
        }
    }
}