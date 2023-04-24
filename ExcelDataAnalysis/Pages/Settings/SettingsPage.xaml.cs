using System.Windows.Controls;
using ExcelDataAnalysis.ViewModels.Settings;

namespace ExcelDataAnalysis.Pages.Settings;

public partial class SettingsPage : Page
{
    public SettingsPage()
    {
        InitializeComponent();
        SettingsView.DataContext = new SettingsViewModel();
    }
}