using RxReminder.Views;
using Microsoft.Maui.Controls;

namespace RxReminder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MedicationInputForm), typeof(MedicationInputForm));
            Routing.RegisterRoute(nameof(MedicationDetailView), typeof(MedicationDetailView));
        }
    }
}
