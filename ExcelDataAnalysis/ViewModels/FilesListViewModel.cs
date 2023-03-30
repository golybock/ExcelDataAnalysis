using System;
using System.Collections.Generic;
using ExcelDataAnalysis.Models;

namespace ExcelDataAnalysis.ViewModels;

public class FilesListViewModel
{
    public int Id { get; set; }
    public string Date { get; set; } = "Пример строки";
    public List<ExcelFile> Files { get; set; } = new List<ExcelFile>()
    {
        new ExcelFile() { FileName = "File1" },
        new ExcelFile() { FileName = "File2" },
        new ExcelFile() { FileName = "File3" }
    };
}