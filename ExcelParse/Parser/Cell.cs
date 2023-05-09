namespace ExcelParse.Parser;

public class Cell
{
    public string Name { get; set; } = string.Empty;

    public int Column { get; set; }

    public string FinalName { get; set; } = string.Empty;
}