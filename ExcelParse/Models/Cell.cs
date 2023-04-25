namespace ExcelParse.Models;

public class Cell
{
    public int Column { get; set; }
    
    public int Row { get; set; }
    
    public char ColumnChar { get; set; }

    public string Position => $"{ColumnChar}{Row}";
}