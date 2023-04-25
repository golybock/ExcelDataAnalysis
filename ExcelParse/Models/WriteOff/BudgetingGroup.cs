namespace ExcelParse.Models.WriteOff;

public class BudgetingGroup : Cell
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
}