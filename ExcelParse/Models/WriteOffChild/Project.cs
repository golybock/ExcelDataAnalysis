namespace ExcelParse.Models.WriteOffChild;

public class Project : Cell
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
}