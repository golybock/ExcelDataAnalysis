namespace ExcelParse.Models.Contract;

public class Contract
{
    public int Id { get; set; }
    
    public int Number { get; set; }
    
    public int DivisionId { get; set; }
    
    public Division? Division { get; set; }
}