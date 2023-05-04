using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ExcelDataAnalysis.Models.Dictionary;
using ExcelDataAnalysis.Models.Settings;
using ExcelDataAnalysis.ViewModels.Settings;
using ExcelParse.Parser.Cfo;
using Microsoft.Win32;

namespace ExcelDataAnalysis.Pages.Settings;

public partial class SettingsPage : Page
{
    private AppSettings? _appSettings;
    public SettingsPage()
    {
        InitializeComponent();
        ReadAppSettings();
        
    }
    public AppSettings? AppSettings
    {
        get => _appSettings;
        set
        {
            if (Equals(value, _appSettings)) return;
            _appSettings = value;
        }
    }

    private async void ReadAppSettings()
    {
        AppSettings = App.AppSettings;
    }
    
    private string? ChooseFile()
    {
        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = "c:\\",
            Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        };
        
        if (openFileDialog.ShowDialog() == true)
            return openFileDialog.FileName;

        return null;
    }

    private async void SaveCfoSettings()
    {
        var filePath = ChooseFile();

        if (AppSettings != null && !string.IsNullOrEmpty(filePath))
        {
            AppSettings.CfoDictionaryPath = filePath;
            await App.SaveSettingsAsync(AppSettings);
            await WriteDefaultCfoDictionary(filePath);
        }
        
        ReadAppSettings();
    }
    
    private void RestoreSettings()
    {
        App.RestoreAppSettings();
        AppSettings = App.AppSettings;
    }

    private async void SavePlacesSettings()
    {
        var filePath = ChooseFile();

        if (AppSettings != null && !string.IsNullOrEmpty(filePath))
        {
            AppSettings.PlacesDictionaryPath = filePath;
            await App.SaveSettingsAsync(AppSettings);
        }
        
        ReadAppSettings();
    }

    private async void SaveArticleSettings()
    {
        var filePath = ChooseFile();

        if (AppSettings != null && !string.IsNullOrEmpty(filePath))
        {
            AppSettings.ArticlesDictionaryPath = filePath;
            await App.SaveSettingsAsync(AppSettings);
        }
        
        ReadAppSettings();
    }

    private void ShowFileInExplorerCfo()
    {
        if (AppSettings != null)
            Process.Start(new ProcessStartInfo
                {
                    FileName = "explorer", Arguments = $"/n, /select, {AppSettings.CfoDictionaryPath}"
                }
            );
    }

    private void ShowFileExplorerPlaces()
    {
        if (AppSettings != null)
            Process.Start(new ProcessStartInfo
                {
                    FileName = "explorer", Arguments = $"/n, /select, {AppSettings.PlacesDictionaryPath}"
                }
            );
    }
    
    private void ShowFileExplorerArticle()
    {
        if (AppSettings != null)
            Process.Start(new ProcessStartInfo
                {
                    FileName = "explorer", Arguments = $"/n, /select, {AppSettings.ArticlesDictionaryPath}"
                }
            );
    }

    private async Task WriteDefaultCfoDictionary(string path)
    {
        var cfoParser = new CfoParser(path);

        var cfos = cfoParser.Get();

        var writer = new DictionaryJsonWriter();
        
        await writer.WriteCfoDictionary(cfos);
    }

    private void ArticleSelectButton_OnClick(object sender, RoutedEventArgs e)
    {
        SaveCfoSettings();
    }

    private void RestoreButton_OnClick(object sender, RoutedEventArgs e)
    {
        RestoreSettings();
    }

    private void CfoSelectButton_OnClick(object sender, RoutedEventArgs e)
    {
        SaveCfoSettings();
    }

    private void PlacesSelectButton_OnClick(object sender, RoutedEventArgs e)
    {
        SavePlacesSettings();
    }
}