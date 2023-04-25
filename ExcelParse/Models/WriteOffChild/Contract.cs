

namespace ExcelParse.Models.WriteOffChild;

public class Contract : Cell
{
    public Contract()
    {
        Division = new Division();
    }

    public int Id { get; set; }
    
    public int Number { get; set; }

    public Division Division { get; set; }
    
    public int DivisionId { get; set; }
}