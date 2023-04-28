namespace ExcelDataAnalysis.Models;

public class UploadFile
{
    public int Id { get; set; }
    public string? FilePath { get; set; }
    private string? FileType { get; set; }
}