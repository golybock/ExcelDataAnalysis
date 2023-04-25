using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using ExcelDataAnalysis.Models.Command;

namespace ExcelDataAnalysis.ViewModels.Settings;

public class AboutUsViewModel : INotifyPropertyChanged
{
    private bool _popupIsOpen;
    
    public string SupportEmail { get; } = "danila.arschinov@yandex.ru";

    public string Version { get; } = "1.0 b";
    
    public bool PopupIsOpen
    {
        get => _popupIsOpen;
        set
        {
            if (value == _popupIsOpen) return;
            _popupIsOpen = value;
            OnPropertyChanged();
        }
    }
    
    public CommandHandler CopyEmailCommand => new(OnCopy);

    private async void OnCopy()
    {
        try
        {
            Clipboard.SetText(SupportEmail);
            
            PopupIsOpen = true;
            
            await Task.Delay(1500);
            
            PopupIsOpen = false;
        }
        catch (Exception e)
        {
            //
        }
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