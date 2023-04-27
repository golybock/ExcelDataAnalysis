namespace ExcelParse.Models.Dictionaries;

public class PlaceDictionary
{
    public int Id { get; set; }

    public string CorrectAddress { get; set; } = string.Empty;

    public decimal Square { get; set; }
    
    public int CountPlaces { get; set; }

    public string PlaceType { get; set; } = string.Empty;
    
    public string RegionName { get; set; } = string.Empty;

    public string RegionBusinessName { get; set; } = string.Empty;

    public string ObjectTypeName { get; set; } = string.Empty;

    public override string ToString()
    {
        string result = string.Empty;

        result += $"Id {Id}\n";
        result += $"CorrectAddress: {CorrectAddress}\n";
        result += $"Square: {Square}\n";
        result += $"CountPlaces: {CountPlaces}\n";
        result += $"PlaceType: {PlaceType}\n";
        result += $"RegionName: {RegionName}\n";
        result += $"RegionBusinessName: {RegionBusinessName}\n";
        result += $"ObjectTypeName {ObjectTypeName}";
        
        return result;
    }
}