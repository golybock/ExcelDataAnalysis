using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExcelDataAnalysis.Models;
using ExcelDataAnalysis.Models.Command;
using ExcelDataAnalysis.Models.Settings;
using ExcelParse.Parser.Main;
using Microsoft.Win32;

namespace ExcelDataAnalysis.ViewModels.Upload;

public class UploadViewModel : INotifyPropertyChanged
{
    private AppSettings? _appSettings;
    
    public UploadViewModel()
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

    public CommandHandler ClearCommand =>
        new CommandHandler(ClearList);

    public CommandHandler ComputeCommand =>
        new CommandHandler(Compute);

    public CommandHandler AddCommand =>
        new CommandHandler(AddFile);
    
    public CommandHandler<UploadFile> DeleteCommand =>
        new CommandHandler<UploadFile>(Delete);

    private void ClearList()
    {
        UploadedFiles = new ObservableCollection<UploadFile>();
        OnPropertyChanged("UploadedFiles");
    }

    private void Compute()
    {
        MainParser parser = new MainParser();
        parser.Generate();
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

    private void AddFile()
    {
        string? file = ChooseFile();
        UploadFile uploadFile = new UploadFile()
        {
            FilePath = file
        };
       

        if (file != null) UploadedFiles.Add(uploadFile);
        
        OnPropertyChanged("UploadedFiles");
    }

    private void Delete(UploadFile uploadFile)
    {
        UploadedFiles.Remove(uploadFile);
        OnPropertyChanged("UploadedFiles");
    }
    
    
    private async void ReadAppSettings()
    {
        AppSettings = App.AppSettings;
    }
    
    public ObservableCollection<UploadFile> UploadedFiles { get; set; } = new ObservableCollection<UploadFile>();

     

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