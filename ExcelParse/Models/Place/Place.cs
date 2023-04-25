namespace ExcelParse.Models.Place;

public class Place : Cell
{
    public Place()
    {
        ObjectType = new ObjectType();
        PlaceType = new PlaceType();
        Region = new Region();
    }

    public int Id { get; set; }

    public string Address { get; set; } = string.Empty;
    
    public decimal Square { get; set; }

    public ObjectType ObjectType { get; set; }
    
    public int ObjectTypeId { get; set; }
    
    public int CountPlaces { get; set; }

    public PlaceType PlaceType { get; set; }
    
    public int PlaceTypeId { get; set; }

    public Region Region { get; set; }
    
    public int RegionId { get; set; }
}