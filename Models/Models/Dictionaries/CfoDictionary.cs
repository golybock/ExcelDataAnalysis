namespace Models.Models.Dictionaries;

public class CfoDictionary
{
    /// <summary>
    /// Id для служебных нужд
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование ЦФО верхнего уровня
    /// </summary>
    public string UpperCfoName { get; set; } = string.Empty;

    /// <summary>
    /// Цфо верхнего уровня
    /// </summary>
    public string UpperCfo { get; set; } = string.Empty;

    /// <summary>
    ///  ЦФО для плана
    /// </summary>
    public string PlanCfoName { get; set; } = string.Empty;
    /// <summary>
    /// Наименование ЦФУ
    /// </summary>
    public string CfuName { get; set; } = string.Empty;
    /// <summary>
    ///  ЦФУ
    /// </summary>
    public string Cfu { get; set; } = string.Empty;

    public override string ToString()
    {
        string result = string.Empty;

        result += $"Id: {Id}\n";
        result += $"UpperCfoName: {UpperCfoName}\n";
        result += $"UpperCfoCode: {UpperCfo}\n";
        result += $"PlanCfoName: {PlanCfoName}\n";
        result += $"CfuName: {CfuName}\n";
        result += $"CfuCode: {Cfu}\n";

        return result;
    }
}