using OfficeOpenXml;

namespace ExcelParse.Parser;

public class ParserBase
{
    protected ExcelPackage GetParser(string path)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        return new(new FileInfo(path));
    }
        
}