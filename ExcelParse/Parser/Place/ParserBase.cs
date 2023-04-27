using OfficeOpenXml;

namespace ExcelParse.Parser.Place;

public class ParserBase
{
    // erros in lines
    protected List<int> _errors = new List<int>();

    protected ExcelPackage GetParser(string path)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        return new(new FileInfo(path));
    }
        
}