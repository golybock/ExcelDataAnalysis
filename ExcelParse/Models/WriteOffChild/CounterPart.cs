﻿namespace ExcelParse.Models.WriteOffChild;

public class CounterPart : Cell
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public int Number { get; set; }
}