using OfficeOpenXml;

namespace ExcelParse.Parser;

public class ParserBase
{
    // log level
    protected bool _log = false;
    
    // path to file to read
    protected string _path = String.Empty;
    
    // erros in lines
    protected List<int> _errors = new List<int>();

    /// <summary>
    /// Возвращает объект класса для дальнейшего парсинга
    /// </summary>
    /// <param name="path">Путь до файла</param>
    /// <returns>Объект парсера</returns>
    protected ExcelPackage GetParser(string path)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        return new(new FileInfo(path));
    }

    /// <summary>
    /// Логирует номера строк, в которых возникла ошибка
    /// </summary>
    /// <exception cref="Exception">
    /// Вызывает исключение, если логирование было отключено при создании объекта класса
    /// </exception>
    public void Log()
    {
        if (_log)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erros: {_errors.Count}");
            Console.ForegroundColor = ConsoleColor.White;    
        }
        else
        {
            throw new Exception("Log is disabled");
        }
    }
    
}