namespace ExcelParse.Models.Dictionaries;

public class CfoDictionary
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string UpperCfoName { get; set; } = string.Empty;

    public string UpperCfoCode { get; set; } = string.Empty;

    public string PlanCfoName { get; set; } = string.Empty;

    public string CfuName { get; set; } = string.Empty;

    public string CfuCode { get; set; } = string.Empty;

    public override string ToString()
    {
        string result = string.Empty;

        result += $"Id: {Id}\n";
        result += $"Name: {Name}\n";
        result += $"Code: {Code}\n";
        result += $"UpperCfoName: {UpperCfoName}\n";
        result += $"UpperCfoCode: {UpperCfoCode}\n";
        result += $"PlanCfoName: {PlanCfoName}\n";
        result += $"CfuName: {CfuName}\n";
        result += $"CfuCode: {CfuCode}\n";
        
        return result;
    }
}