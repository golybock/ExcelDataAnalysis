namespace ExcelParse.Models;

public class Article:Cell
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
}