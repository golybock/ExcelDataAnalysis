namespace Models.Models.Dictionaries;

public class PlaceDictionary
{
    /// <summary>
    /// Id для служебных нужд
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Тип площади
    /// </summary>
    public string PlaceType { get; set; } = string.Empty;

    /// <summary>
    /// Название региона
    /// </summary>
    public string RegionName { get; set; } = string.Empty;

    /// <summary>
    ///  Название бизнес региона
    /// </summary>
    public string RegionBusinessName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string CorrectAddress { get; set; } = string.Empty;

    /// <summary>
    /// Метраж полезных помещений
    /// </summary>
    public decimal Square { get; set; }

    /// <summary>
    ///  Тип объекта
    /// </summary>
    public string ObjectTypeName { get; set; } = string.Empty;

    /// <summary>
    ///  Кол-во типов площадей
    /// </summary>
    public int CountPlaces { get; set; }

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