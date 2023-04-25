namespace ExcelParse.Models.CfoChild;

public class Cfo : Cell
{
    public Cfo()
    {
        UpperCfo = new UpperCfo();
        PlanCfo = new PlanCfo();
        Cfu = new Cfu();
    }
    public int Id { get; set; }

    public UpperCfo UpperCfo { get; set; }

    private int UpperCfoId { get; set; }

    public PlanCfo PlanCfo { get; set; }
    
    public int PlanCfoId { get; set; }

    public Cfu Cfu { get; set; }
    
    public int CfuId { get; set; }

}