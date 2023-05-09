using OfficeOpenXml;

namespace ExcelParse.Parser.Main;

public class MainParser : ParserBase
{
    private readonly string PaymentDate = "Дата оплаты";
    private readonly string Article = "Статья";
    private readonly string ArticleName = "Наименование статьи";
    private readonly string CfuCode = "ЦФУ";
    private readonly string CfuName = "Наименование ЦФУ";
    private readonly string StatusAndTd = "Статус Площадь объекта";
    
    private readonly int PaymentDateColumn = 1;
    private readonly int ArticleColumn = 2;
    private readonly int ArticleNameColumn = 3;
    private readonly int CfuCodeColumn = 11;
    private readonly int CfuNameColumn = 12;
    private readonly int StatusAndTdColumn = 36;
    
    public string Generate()
    {
        throw new NotImplementedException();
        
        string path = $"C:/Users/{Environment.UserName}/Documents/{Guid.NewGuid()}.xlsx";
        
        File.Copy("base.xlsx", path);

        var parser = GetParser(path);
        
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
                        worksheet.Cells[row, 1].Value = "aboba";
                    }
                    catch (Exception e)
                    {
                        _errors.Add(row);
                    }
                }
                
                // save
                File.WriteAllBytes(path, parser.GetAsByteArray());
            }
        }

        return path;
    }
}