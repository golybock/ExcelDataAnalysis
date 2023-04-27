using ExcelParse.Models.Dictionaries;
using ExcelParse.Parser.Place;
using OfficeOpenXml;

namespace ExcelParse.Parser.Cfo;

public class CfoParser : ParserBase
{
    private string _path = string.Empty;

    private readonly string _cfu = "ЦФУ";
    private readonly string _cfuName = "Наименование ЦФУ";
    private readonly string _upperCfo = "ЦФО верхнего уровня";
    private readonly string _upperCfoName = "Наименование ЦФО верхнего уровня";
    private readonly string _planCfo = "ЦФО для плана";

    private int _cfuColumn { get; set; }
    private int _cfuNameColumn { get; set; }
    private int _upperCfoColumn { get; set; }
    private int _upperCfoNameColumn { get; set; }
    private int _planCfoColumn { get; set; }

    public CfoParser(string path)
    {
        _path = path;
    }

    private void FindColumns()
    {
        var parser = GetParser(_path);

        if (parser == null)
            throw new Exception("Ошибка создания парсера");

        using var worksheet = parser.Workbook.Worksheets[0];

        for (int col = 1; col <= 5; col++)
        {
            string? value = worksheet.Cells[1, col].Value?.ToString();

            if (value != null)
            {
                if (value == _cfu)
                    _cfuColumn = col;

                if (value == _cfuName)
                    _cfuNameColumn = col;

                if (value == _upperCfo)
                    _upperCfoColumn = col;

                if (value == _upperCfoName)
                    _upperCfoNameColumn = col;

                if (value == _planCfo)
                    _planCfoColumn = col;
            }
        }
    }

    public void WriteColumns()
    {
        FindColumns();
        Console.WriteLine($"{_cfu} {_cfuColumn}");
        Console.WriteLine($"{_cfuName} {_cfuNameColumn}");
        Console.WriteLine($"{_upperCfo} {_upperCfoColumn}");
        Console.WriteLine($"{_upperCfoName} {_upperCfoNameColumn}");
        Console.WriteLine($"{_planCfo} {_planCfoColumn}");
    }

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

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erros: {_errors.Count}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        return cfos;
    }
}