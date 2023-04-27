using ExcelParse.Models.Dictionaries;
using ExcelParse.Parser.Place;
using OfficeOpenXml;

namespace ExcelParse.Parser;

public class PlaceParser : ParserBase
{
    private readonly string _path;

    private readonly string _placeType = "Тип площади";
    private readonly string _regionName = "Название региона";
    private readonly string _buisnessRegionName = "Название бизнес региона";
    private readonly string _correctAddress = "Правильный адрес";
    private readonly string _square = "Метраж полезных (адресных) помещений";
    private readonly string _objectType = "Тип объекта";
    private readonly string _countPlaces = "Кол-во типов площадей";

    private int _placeTypeColumn { get; set; }
    private int _regionNameColumn { get; set; }
    private int _buisnessRegionNameColumn { get; set; }
    private int _correctAddressColumn { get; set; }
    private int _squareColumn { get; set; }
    private int _objectTypeColumn { get; set; }
    private int _countPlacesColumn { get; set; }

    public PlaceParser(string path)
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
                if (value == _placeType)
                    _placeTypeColumn = col;

                if (value == _regionName)
                    _regionNameColumn = col;

                if (value == _buisnessRegionName)
                    _buisnessRegionNameColumn = col;

                if (value == _correctAddress)
                    _correctAddressColumn = col;

                if (value == _square)
                    _squareColumn = col;

                if (value == _objectType)
                    _objectTypeColumn = col;

                if (value == _countPlaces)
                    _countPlacesColumn = col;
            }
        }
    }

    public List<PlaceDictionary> Get()
    {
        FindColumns();

        var parser = GetParser(_path);

        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        List<PlaceDictionary> articles = new List<PlaceDictionary>();

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
                        PlaceDictionary place = new PlaceDictionary();

                        place.Id = row - 1;

                        place.PlaceType = worksheet.Cells[row, _placeTypeColumn].Value?.ToString()!;
                        place.ObjectTypeName = worksheet.Cells[row, _objectTypeColumn].Value?.ToString()!;
                        place.CountPlaces = int.Parse(worksheet.Cells[row, _countPlacesColumn].Value?.ToString()!);
                        place.Square = decimal.Parse(worksheet.Cells[row, _squareColumn].Value?.ToString()!);
                        place.CorrectAddress = worksheet.Cells[row, _correctAddressColumn].Value?.ToString()!;
                        place.RegionName = worksheet.Cells[row, _regionNameColumn].Value?.ToString()!;
                        place.RegionBusinessName = worksheet.Cells[row, _buisnessRegionNameColumn].Value?.ToString()!;
                      
                        Console.WriteLine($"{place}\n");
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