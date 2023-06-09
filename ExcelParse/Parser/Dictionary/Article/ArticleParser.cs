﻿using Models.Models.Dictionaries;
using OfficeOpenXml;

namespace ExcelParse.Parser.Dictionary.Article;

public class ArticleParser : ParserBase, IParserReader<ArticleDictionary>
{
    private readonly Cell _group = new Cell() {Name = "Группа"};
    private readonly Cell _sourceArticle = new Cell() {Name = "Статья исходника"};
    private readonly Cell _expensesOwner = new Cell() {Name = "Владелец расходов"};
    private readonly Cell _correctArticle = new Cell() {Name = "Статья правильная"};
    private readonly Cell _sourceArticleName = new Cell() {Name = "Наименование статьи исходника"};
    private readonly Cell _correctArticleName = new Cell() {Name = "Наименование статьи правильное"};
    private readonly Cell _unifiedExpenseAssignment = new Cell() {Name = "Унифицированное назначение расхода"};

    /// <summary>
    /// Список для оптимизации поиска ячеек
    /// </summary>
    private readonly List<Cell> _cells;

    /// <summary>
    /// Конструктор с путем до файла с парсингом
    /// </summary>
    /// <param name="path">Путь до файла</param>
    public ArticleParser(string path)
    {
        _path = path;

        _cells = new List<Cell>()
        {
            _group,
            _sourceArticle,
            _expensesOwner,
            _correctArticle,
            _sourceArticleName,
            _correctArticleName,
            _unifiedExpenseAssignment
        };
    }

    /// <summary>
    /// Конструктор с логированием(дополняет предыдущий конструктор)
    /// </summary>
    /// <param name="path">Путь до файла</param>
    /// <param name="log">Булевое значение для логирования</param>
    public ArticleParser(string path, bool log)
    {
        _path = path;
        _log = log;

        _cells = new List<Cell>()
        {
            _group,
            _sourceArticle,
            _expensesOwner,
            _correctArticle,
            _sourceArticleName,
            _correctArticleName,
            _unifiedExpenseAssignment
        };
    }
    
    // подробный комментарий в интерфейсе
    public void FindColumns()
    {
        // объект-парсер
        var parser = GetParser(_path);

        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        // рабочий лист
        using var worksheet = parser.Workbook.Worksheets[0];

        // проход по заголовку таблицы
        for (int col = 1; col <= 15; col++)
        {
            // значение в ячейке
            string? value = worksheet.Cells[1, col].Value?.ToString();

            // проходимся по сипску ячеек и ищем совпадения
            foreach (var cell in _cells)
                if (value == cell.Name)
                    cell.Column = col;
        }

        foreach (var cell in _cells)
            if (cell.Column == 0)
                throw new Exception($"Колонка не найдена: {cell.Name}");
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
    public List<ArticleDictionary> Get()
    {
        // ищем положения ячеек
        FindColumns();

        // объект-парсер
        var parser = GetParser(_path);

        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        // лист для записи данных из строк
        List<ArticleDictionary> articles = new List<ArticleDictionary>();

        // обязательно using для закрытия файла
        using (parser)
        {
            using (ExcelWorksheet worksheet = parser.Workbook.Worksheets[0])
            {
                // кол-во не пустых строк в файле
                int rowCount = worksheet.Dimension.End.Row;

                // начинаем со 2 строки и до конца файла(не пустых строк)
                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        articles.Add(ReadArticle(worksheet, row));
                    }
                    catch (Exception e)
                    {
                        _errors.Add(row);
                    }
                }
            }
        }
        
        return articles;
    }
}