using System.Windows.Controls;
using ExcelDataAnalysis.ViewModels.Upload;
using ExcelDataAnalysis.Views.Upload;

namespace ExcelDataAnalysis.Pages.Upload;

public partial class UploadPage : Page
{
    public UploadPage()
    {
        InitializeComponent();
        UploadView.DataContext =  new UploadViewModel();
    }
}