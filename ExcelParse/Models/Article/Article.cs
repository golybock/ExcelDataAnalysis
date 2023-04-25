namespace ExcelParse.Models.Article;

public class Article : Cell
{
    public int Id { get; set; }

    public int SourceArticleId { get; set; }

    public int CorrectArticleId { get; set; }

    public int PurposeOfExpenseId { get; set; }

    public int ExpenseOwnerId { get; set; }
    
    public SourceArticle? SourceArticle { get; set; }

    public CorrectArticle? CorrectArticle { get; set; }

    public PurposeOfExpense? PurposeOfExpense { get; set; }
    
    public ExpenseOwner? ExpenseOwner { get; set; }
}