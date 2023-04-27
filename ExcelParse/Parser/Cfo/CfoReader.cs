using OfficeOpenXml;

namespace ExcelParse.Parser.Cfo;

public class CfoReader
{
    private ExcelWorksheet _worksheet;
    private int _cfuColumn { get; set; }
    private int _cfuNameColumn { get; set; }
    private int _upperCfoColumn { get; set; }
    private int _upperCfoNameColumn { get; set; }
    private int _planCfoColumn { get; set; }

    public CfoReader(ExcelWorksheet worksheet, int cfuColumn, int cfuNameColumn, int upperCfoColumn,
        int upperCfoNameColumn, int planCfoColumn)
    {
        _worksheet = worksheet;
        _cfuColumn = cfuColumn;
        _cfuNameColumn = cfuNameColumn;
        _upperCfoColumn = upperCfoColumn;
        _upperCfoNameColumn = upperCfoNameColumn;
        _planCfoColumn = planCfoColumn;
    }

    public Models.Cfo.Cfo Read(int row)
    {
        Models.Cfo.Cfo cfo = new Models.Cfo.Cfo();

        cfo.Id = row - 1;
        
        cfo.UpperCfo.Code = _worksheet.Cells[row, _upperCfoColumn].Value?.ToString()!;
        cfo.UpperCfo.Name = _worksheet.Cells[row, _upperCfoNameColumn].Value?.ToString()!;

        cfo.Cfu.Code = _worksheet.Cells[row, _cfuColumn].Value?.ToString()!;
        cfo.Cfu.Name = _worksheet.Cells[row, _cfuNameColumn].Value?.ToString()!;
        
        cfo.PlanCfo.Name = _worksheet.Cells[row, _planCfoColumn].Value?.ToString()!;
        
        return cfo;
    }
}