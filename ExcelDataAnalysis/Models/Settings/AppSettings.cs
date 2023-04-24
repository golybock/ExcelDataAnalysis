using System.IO;

namespace ExcelDataAnalysis.Models.Settings;

public class AppSettings
{
    // путь до справочника ЦФО
    public string CfoDictionaryPath { get; set; } = string.Empty;

    // путь до справочника Кол-во типов площадей
    public string CountPlacesDictionaryPath { get; set; } = string.Empty;

    // путь до справочника статей
    public string ArticlesDictionaryPath { get; set; } = string.Empty;
}