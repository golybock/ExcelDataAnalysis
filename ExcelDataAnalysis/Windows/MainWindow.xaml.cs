using System.Windows;
using System.Windows.Input;
using ExcelDataAnalysis.Pages;
using ExcelDataAnalysis.Pages.Settings;
using ExcelDataAnalysis.Pages.Upload;
using ModernWpf.Controls;
using Page = System.Windows.Controls.Page;

namespace ExcelDataAnalysis.Windows
{
    public partial class MainWindow : Window
    {
        private NavigationViewItem? _lastItem = null;
        
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.NavigationService.Navigate(new FilesListPage());
        }

        private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;

            if (item == null || item == _lastItem) return;

            var clickedView = item.Tag?.ToString();

            if (!NavigateView(clickedView)) return;

            _lastItem = item;
        }

        private bool NavigateView(string? view)
        {
            if (string.IsNullOrWhiteSpace(view))
                return false;

            var page = GetPage(view);
        
            if(page != null)
                MainFrame.Navigate(page);

            return true;
        }

        private Page? GetPage(string pageName)
        {
            if (pageName == "SettingsPage")
                return new SettingsPage();
            
            if (pageName == "FilesPage")
                return new FilesListPage();
            
            if (pageName == "UploadFile")
                return new UploadPage();

            return null;
        }
    }
}