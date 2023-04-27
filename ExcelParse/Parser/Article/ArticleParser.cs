using ExcelParse.Models.Dictionaries;
using ExcelParse.Parser.Place;
using OfficeOpenXml;

namespace ExcelParse.Parser.Article;

public class ArticleParser : ParserBase
{
    private readonly string _path;

    private readonly string _group = "Группа";
    private readonly string _correctArticleName = "Наименование статьи правильное";
    private readonly string _sourceArticle = "Статья исходника";
    private readonly string _sourceArticleName = "Наименование статьи исходника";
    private readonly string _correctArticle = "Статья правильная";
    private readonly string _unifiedExpenseAssignment = "Унифицированное назначение расхода";
    private readonly string _ExpensesOwner = "Владелец расходов";

    private int _groupColumn { get; set; }
    private int _correctArticleNameColumn { get; set; }
    private int _sourceArticleColumn { get; set; }
    private int _sourceArticleNameColumn { get; set; }
    private int _correctArticleColumn { get; set; }
    private int _unifiedExpenseAssignmentColumn { get; set; }
    private int _ExpensesOwnerColumn { get; set; }

    public ArticleParser(string path)
    {
        _path = path;
    }

    // костыль (ищет номера колонок)
    private void FindColumns()
    {
        var parser = GetParser(_path);

        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        using var worksheet = parser.Workbook.Worksheets[0];

        for (int col = 1; col <= 7; col++)
        {
            string? value = worksheet.Cells[1, col].Value?.ToString();

            if (value != null)
            {
                if (value == _group)
                    _groupColumn = col;

                if (value == _correctArticle)
                    _correctArticleColumn = col;

                if (value == _correctArticleName)
                    _correctArticleNameColumn = col;

                if (value == _sourceArticle)
                    _sourceArticleColumn = col;

                if (value == _sourceArticleName)
                    _sourceArticleNameColumn = col;

                if (value == _unifiedExpenseAssignment)
                    _unifiedExpenseAssignmentColumn = col;

                if (value == _ExpensesOwner)
                    _ExpensesOwnerColumn = col;
            }
        }
    }

    public List<ArticleDictionary> Get()
    {
        FindColumns();

        var parser = GetParser(_path);

        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        List<ArticleDictionary> articles = new List<ArticleDictionary>();

        using (parser)
        {
            using (ExcelWorksheet worksheet = parser.Workbook.Worksheets[0])
            {
                // int columnCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;
                
                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        ArticleDictionary article = new ArticleDictionary();

                        article.Id = row - 1;
        
                        article.Group = Int32.Parse(worksheet.Cells[row, _groupColumn].Value?.ToString()!);
                        article.CorrectArticleName = worksheet.Cells[row, _correctArticleNameColumn].Value?.ToString()!;
                        article.CorrectArticleId =
                            Int32.Parse(worksheet.Cells[row, _correctArticleColumn].Value?.ToString()!);

                        article.SourceArticleName = worksheet.Cells[row, _sourceArticleNameColumn].Value?.ToString()!;
                        article.SourceArticleId = Int32.Parse(worksheet.Cells[row, _sourceArticleColumn].Value?.ToString()!);

                        article.ExpenseOwnerName = worksheet.Cells[row, _ExpensesOwnerColumn].Value?.ToString()!;

                        article.PurposeOfExpenseName =
                            worksheet.Cells[row, _unifiedExpenseAssignmentColumn].Value?.ToString()!;
                    
                        Console.WriteLine($"{article}\n");
                    }
                    catch (Exception e)
                    {
                        _errors.Add(row);
                    }

                }
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erros: {_errors.Count}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        return articles;
    }
}