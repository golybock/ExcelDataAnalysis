﻿namespace ExcelParse.Models.CfoChild;

public class UpperCfo : Cell
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Code { get; set; } = string.Empty;
}