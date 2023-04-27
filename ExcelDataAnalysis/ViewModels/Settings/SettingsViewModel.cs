using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using ExcelDataAnalysis.Models.Command;
using ExcelDataAnalysis.Models.Dictionary;
using ExcelDataAnalysis.Models.Settings;
using ExcelParse.Parser.Cfo;
using Microsoft.Win32;

namespace ExcelDataAnalysis.ViewModels.Settings;

public class SettingsViewModel : INotifyPropertyChanged
{
    private AppSettings? _appSettings;

    public SettingsViewModel()
    {
        ReadAppSettings();
    }

    public AppSettings? AppSettings
    {
        get => _appSettings;
        set
        {
            if (Equals(value, _appSettings)) return;
            _appSettings = value;
            OnPropertyChanged();
        }
    }

    private async void ReadAppSettings()
    {
        AppSettings = App.AppSettings;
    }

    public CommandHandler SelectCfoCommand =>
        new CommandHandler(SaveCfoSettings);

    public CommandHandler SelectPlacesCommand =>
        new CommandHandler(SavePlacesSettings);

    public CommandHandler SelectArticleCommand => 
        new CommandHandler(SaveArticleSettings);

    public CommandHandler OpenCfoCommand =>
        new CommandHandler(ShowFileInExplorerCfo);
    
    public CommandHandler OpenPlacesCommand =>
        new CommandHandler(ShowFileExplorerPlaces);

    public CommandHandler OpenArticleCommand =>
        new CommandHandler(ShowFileExplorerArticle);

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
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}