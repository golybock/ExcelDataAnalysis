using Models.Models.Dictionaries;
using OfficeOpenXml;

namespace ExcelParse.Parser.Cfo;

public class CfoParser :  ParserBase, IParserReader<CfoDictionary>
{
    private readonly Cell _cfu = new Cell(){ Name = "ЦФУ"};
    private readonly Cell _planCfo = new Cell(){Name = "ЦФО для плана"};
    private readonly Cell _cfuName = new Cell(){Name = "Наименование ЦФУ"};
    private readonly Cell _upperCfo = new Cell(){Name = "ЦФО верхнего уровня"};
    private readonly Cell _upperCfoName = new Cell(){Name = "Наименование ЦФО верхнего уровня"};

    /// <summary>
    /// Список для оптимизации поиска ячеек
    /// </summary>
    private readonly List<Cell> _cells;
    
    /// <summary>
    /// Конструктор с путем до файла с парсингом
    /// </summary>
    /// <param name="path">Путь до файла</param>
    public CfoParser(string path)
    {
        _path = path;

        _cells = new List<Cell>()
        {
            _cfu,
            _planCfo,
            _cfuName,
            _upperCfo,
            _upperCfoName
        };
    }
    
    /// <summary>
    /// Конструктор с логированием(дополняет предыдущий конструктор)
    /// </summary>
    /// <param name="path">Путь до файла</param>
    /// <param name="log">Булевое значение для логирования</param>
    public CfoParser(string path, bool log)
    {
        _path = path;
        _log = log;

        _cells = new List<Cell>()
        {
            _cfu,
            _planCfo,
            _cfuName,
            _upperCfo,
            _upperCfoName
        };
    }
    
    // подробный комментарий в интерфейсе
    public void FindColumns()
    {
        var parser = GetParser(_path);

        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        using var worksheet = parser.Workbook.Worksheets[0];

        for (int col = 1; col <= 15; col++)
        {
            // значение в ячейке
            string? value = worksheet.Cells[1, col].Value?.ToString();

            // проходимся по сипску ячеек и ищем совпадения
            foreach (var cell in _cells)
                if (value == cell.Name)
                    cell.Column = col;
        }
    }
    
    /// <summary>
    /// Возвращает объект класса ArticleDictionary по положению строки
    /// </summary>
    /// <param name="worksheet">Открытый лист для чтения данных</param>
    /// <param name="row">Номер строки для чтения</param>
    /// <returns>Объект класса с данными из строки</returns>
    private ArticleDictionary ReadArticle(ExcelWorksheet worksheet, int row)
    {
        ArticleDictionary article = new ArticleDictionary();

        article.Id = row - 1;

        article.Group = worksheet
            .Cells[row, _group.Column]
            .Value?
            .ToString()!;

        article.CorrectArticleName = worksheet
            .Cells[row, _correctArticleName.Column]
            .Value?
            .ToString()!;

        article.CorrectArticle = worksheet
            .Cells[row, _correctArticle.Column]
            .Value?
            .ToString()!;

        article.SourceArticleName = worksheet
            .Cells[row, _sourceArticleName.Column]
            .Value?
            .ToString()!;

        article.SourceArticle = worksheet
            .Cells[row, _sourceArticle.Column]
            .Value?
            .ToString()!;

        article.ExpenseOwnerName = worksheet
            .Cells[row, _expensesOwner.Column]
            .Value?
            .ToString()!;

        article.PurposeOfExpenseName = worksheet
            .Cells[row, _unifiedExpenseAssignment.Column]
            .Value?
            .ToString()!;

        if(_log)
            Console.WriteLine($"{article}\n");

        return article;
    }

    // подробный комментарий в интерфейсе
    public List<CfoDictionary> Get()
    {
        FindColumns();

        var parser = GetParser(_path);

        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        List<CfoDictionary> cfos = new List<CfoDictionary>();

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
                        CfoDictionary cfo = new CfoDictionary();

                        cfo.Id = row - 1;

                        cfo.UpperCfoCode = worksheet.Cells[row, _upperCfoColumn].Value?.ToString()!;
                        cfo.UpperCfoName = worksheet.Cells[row, _upperCfoNameColumn].Value?.ToString()!;

                        cfo.CfuCode = worksheet.Cells[row, _cfuColumn].Value?.ToString()!;
                        cfo.CfuName = worksheet.Cells[row, _cfuNameColumn].Value?.ToString()!;

                        cfo.PlanCfoName = worksheet.Cells[row, _planCfoColumn].Value?.ToString()!;

                        cfos.Add(cfo);

                        Console.WriteLine(cfo + "\n");
                    }
                    catch (Exception e)
                    {
                        _errors.Add(row);
                    }
                }
                
            }
        }

        return cfos;
    }
}