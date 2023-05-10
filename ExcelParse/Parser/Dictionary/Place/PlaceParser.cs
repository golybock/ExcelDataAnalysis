using Models.Models.Dictionaries;
using OfficeOpenXml;

namespace ExcelParse.Parser.Dictionary.Place;

public class PlaceParser : ParserBase, IParserReader<PlaceDictionary>
{
    private readonly Cell _placeType = new Cell() {Name = "Тип площади"};
    private readonly Cell _regionName = new Cell() {Name = "Название региона"};
    private readonly Cell _businessRegionName = new Cell() {Name = "Название бизнес региона"};
    private readonly Cell _correctAddress = new Cell() {Name = "Правильный адрес"};
    private readonly Cell _square = new Cell() {Name = "Метраж полезных (адресных) помещений"};
    private readonly Cell _objectType = new Cell() {Name = "Тип объекта"};
    private readonly Cell _countPlaces = new Cell() {Name = "Кол-во типов площадей"};

    /// <summary>
    /// Список для оптимизации поиска ячеек
    /// </summary>
    private readonly List<Cell> _cells;

    /// <summary>
    /// Конструктор с путем до файла с парсингом
    /// </summary>
    /// <param name="path">Путь до файла</param>
    public PlaceParser(string path)
    {
        _path = path;

        _cells = new List<Cell>()
        {
            _placeType,
            _regionName,
            _businessRegionName,
            _correctAddress,
            _square,
            _objectType,
            _countPlaces
        };
    }

    /// <summary>
    /// Конструктор с логированием(дополняет предыдущий конструктор)
    /// </summary>
    /// <param name="path">Путь до файла</param>
    /// <param name="log">Булевое значение для логирования</param>
    public PlaceParser(string path, bool log)
    {
        _path = path;
        _log = log;

        _cells = new List<Cell>()
        {
            _placeType,
            _regionName,
            _businessRegionName,
            _correctAddress,
            _square,
            _objectType,
            _countPlaces
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
    private PlaceDictionary ReadPlace(ExcelWorksheet worksheet, int row)
    {
        PlaceDictionary placeDictionary = new PlaceDictionary();

        placeDictionary.Id = row - 1;

        placeDictionary.PlaceType = worksheet
            .Cells[row, _placeType.Column]
            .Value?
            .ToString()!;

        placeDictionary.RegionName = worksheet
            .Cells[row, _regionName.Column]
            .Value?
            .ToString()!;

        placeDictionary.RegionBusinessName = worksheet
            .Cells[row, _businessRegionName.Column]
            .Value?
            .ToString()!;

        placeDictionary.CorrectAddress = worksheet
            .Cells[row, _correctAddress.Column]
            .Value?
            .ToString()!;

        placeDictionary.Square = decimal.Parse(
            worksheet
                .Cells[row, _square.Column]
                .Value?
                .ToString()!
            );
        
        placeDictionary.ObjectTypeName = worksheet
            .Cells[row, _objectType.Column]
            .Value?
            .ToString()!;
        
        placeDictionary.CountPlaces = int.Parse(
            worksheet
                .Cells[row, _countPlaces.Column]
                .Value?
                .ToString()!
        );

        if (_log)
            Console.WriteLine($"{placeDictionary}\n");

        return placeDictionary;
    }

    // подробный комментарий в интерфейсе
    public List<PlaceDictionary> Get()
    {
        // ищем положения ячеек
        FindColumns();

        var parser = GetParser(_path);

        // объект-парсер
        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        // лист для записи данных из строк
        List<PlaceDictionary> places = new List<PlaceDictionary>();

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
                        places.Add(ReadPlace(worksheet, row));
                    }
                    catch (Exception e)
                    {
                        _errors.Add(row);
                    }
                }
            }
        }

        return places;
    }
}