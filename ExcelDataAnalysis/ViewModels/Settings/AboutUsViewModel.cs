using System;
using System.Windows;
using ExcelDataAnalysis.Models.Command;

namespace ExcelDataAnalysis.ViewModels.Settings;

public class AboutUsViewModel
{
    public string SupportEmail { get; } = "danila.arschinov@yandex.ru";

    public string Version { get; } = "1.0 b";
    
    public CommandHandler CopyEmailCommand => new(OnCopy);

    private void OnCopy()
    {
        try
        {
            Clipboard.SetText(SupportEmail);
        }
        catch (Exception e)
        {
            //
        }
    }
}