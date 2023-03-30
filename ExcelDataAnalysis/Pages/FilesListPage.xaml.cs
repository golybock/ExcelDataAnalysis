using System.Windows.Controls;
using ExcelDataAnalysis.ViewModels;

namespace ExcelDataAnalysis.Pages;

public partial class FilesListPage : Page
{
    public FilesListPage()
    {
        InitializeComponent();
        DataContext = new FilesListViewModel();
    }
}