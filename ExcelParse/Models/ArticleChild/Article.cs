namespace ExcelParse.Models.ArticleChild;

public class Article:Cell
{
    public Article()
    {
        SourceArticle = new SourceArticle();

        CorrectArticle = new CorrectArticle();

        PurposeOfExpense = new PurposeOfExpense();

        ExpenseOwner = new ExpenseOwner();
    }

    public int Id { get; set; }

    public SourceArticle SourceArticle { get; set; }
    
    public int SourceArticleId { get; set; }

    public CorrectArticle CorrectArticle { get; set; }
    
    public int CorrectArticleId { get; set; }

    public PurposeOfExpense PurposeOfExpense { get; set; }
    
    public int PurposeOfExpenseId { get; set; }

    public ExpenseOwner ExpenseOwner { get; set; }
    
    public int ExpenseOwnerId { get; set; }

}