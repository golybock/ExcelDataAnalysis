using System.Windows;
using ExcelDataAnalysis.Pages;

namespace ExcelDataAnalysis.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new FilesListPage());
        }
    }
}