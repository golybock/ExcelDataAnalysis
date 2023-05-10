using Models.Models.Dictionaries;
using OfficeOpenXml;

namespace ExcelParse.Parser.Dictionary.Cfo;

public class CfoParser : ParserBase, IParserReader<CfoDictionary>
{
    private readonly Cell _cfu = new Cell() {Name = "ЦФУ"};
    private readonly Cell _planCfo = new Cell() {Name = "ЦФО для плана"};
    private readonly Cell _cfuName = new Cell() {Name = "Наименование ЦФУ"};
    private readonly Cell _upperCfo = new Cell() {Name = "ЦФО верхнего уровня"};
    private readonly Cell _upperCfoName = new Cell() {Name = "Наименование ЦФО верхнего уровня"};

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
    private CfoDictionary ReadCfo(ExcelWorksheet worksheet, int row)
    {
        CfoDictionary cfoDictionary = new CfoDictionary();

        cfoDictionary.Id = row - 1;

        cfoDictionary.Cfu = worksheet
            .Cells[row, _cfu.Column]
            .Value?
            .ToString()!;

        cfoDictionary.CfuName = worksheet
            .Cells[row, _cfuName.Column]
            .Value?
            .ToString()!;

        cfoDictionary.PlanCfoName = worksheet
            .Cells[row, _planCfo.Column]
            .Value?
            .ToString()!;

        cfoDictionary.UpperCfo = worksheet
            .Cells[row, _upperCfo.Column]
            .Value?
            .ToString()!;

        cfoDictionary.UpperCfoName = worksheet
            .Cells[row, _upperCfoName.Column]
            .Value?
            .ToString()!;

        if (_log)
            Console.WriteLine($"{cfoDictionary}\n");

        return cfoDictionary;
    }

    // подробный комментарий в интерфейсе
    public List<CfoDictionary> Get()
    {
        // ищем положения ячеек
        FindColumns();

        var parser = GetParser(_path);

        // объект-парсер
        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        // лист для записи данных из строк
        List<CfoDictionary> cfos = new List<CfoDictionary>();

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
                        cfos.Add(ReadCfo(worksheet, row));
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