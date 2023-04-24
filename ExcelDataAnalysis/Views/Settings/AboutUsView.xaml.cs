using System.Windows.Controls;
using System.Windows.Input;
using ExcelDataAnalysis.ViewModels.Settings;

namespace ExcelDataAnalysis.Views.Settings;

public partial class AboutUsView : UserControl
{
    public AboutUsView()
    {
        InitializeComponent();
        DataContext = new AboutUsViewModel();
    }
}