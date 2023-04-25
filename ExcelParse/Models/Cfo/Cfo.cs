namespace ExcelParse.Models.Cfo;

public class Cfo : Cell
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
    
    private int UpperCfoId { get; set; }

    public int PlanCfoId { get; set; }

    public int CfuId { get; set; }

    public UpperCfo? UpperCfo { get; set; }

    public PlanCfo? PlanCfo { get; set; }

    public Cfu? Cfu { get; set; }
}