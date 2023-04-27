using System.Data.Common;

namespace ExcelParse.Models.Dictionaries;

public class ArticleDictionary 
{
    public int Id { get; set; }

    public int Group { get; set; }
    
    public int SourceArticleId { get; set; }

    public int CorrectArticleId { get; set; }

    public string SourceArticleName { get; set; } = string.Empty;

    public string CorrectArticleName { get; set; } = string.Empty;

    public string PurposeOfExpenseName { get; set; } = string.Empty;

    public string ExpenseOwnerName { get; set; } = string.Empty;

    public override string ToString()
    {
        string result = string.Empty;

        result += $"id: {Id}\n";
        result += $"Group: {Group}\n";
        result += $"SourceArticleId: {SourceArticleId}\n";
        result += $"SourceArticleName: {SourceArticleName}\n";
        result += $"CorrectArticleName: {CorrectArticleName}\n";
        result += $"PurposeOfExpenseName: {PurposeOfExpenseName}\n";
        result += $"ExpenseOwnerName: {ExpenseOwnerName}";

        return result;
    }
}