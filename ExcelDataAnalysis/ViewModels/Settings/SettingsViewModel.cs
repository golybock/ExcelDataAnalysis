using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using ExcelDataAnalysis.Models.Command;
using ExcelDataAnalysis.Models.Settings;
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
        AppSettings = await App.ReadAppSettings();
    }

    public CommandHandler SelectCfoCommand =>
        new CommandHandler(SaveCfoSettings);

    public CommandHandler SelectPlacesCommand =>
        new CommandHandler(SavePlacesSettings);

    public CommandHandler SelectArticleCommand => 
        new CommandHandler(SaveArticleSettings);

    public CommandHandler OpenCfoCommand =>
        new CommandHandler();
    
    public CommandHandler OpenPlacesCommand =>
        new CommandHandler();
    
    
    
    private string? ChooseFile()
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
        // если показан
        if (openFileDialog.ShowDialog() == true)
            // если есть выбранный файл
            return openFileDialog.FileName;

        return null;
    }

    private async void SaveCfoSettings()
    {
        var filePath = ChooseFile();

        if (AppSettings != null)
        {
            AppSettings.CfoDictionaryPath = filePath;
            await App.WriteAppSettings(AppSettings);
        }
        
        ReadAppSettings();
    }

    private async void SavePlacesSettings()
    {
        var filePath = ChooseFile();

        if (AppSettings != null)
        {
            AppSettings.CountPlacesDictionaryPath = filePath;
            await App.WriteAppSettings(AppSettings);
        }
        
        ReadAppSettings();
    }

    private async void SaveArticleSettings()
    {
        var filePath = ChooseFile();

        if (AppSettings != null)
        {
            AppSettings.ArticlesDictionaryPath = filePath;
            await App.WriteAppSettings(AppSettings);
        }
        
        ReadAppSettings();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
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