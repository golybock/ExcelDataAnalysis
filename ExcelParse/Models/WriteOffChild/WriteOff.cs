using ExcelParse.Models.CfoChild;

namespace ExcelParse.Models.WriteOffChild
{
    public class WriteOff : Cell
    {
        public WriteOff()
        {
            Article = new ArticleChild.Article();
            BudgetingGroup = new BudgetingGroup();
            CounterPart = new CounterPart();
            PaymentInitiator = new PaymentInitiator();
            Cfo = new Cfo();
            Project = new Project();
            Firm = new Firm();
            Place = new Place.Place();
            Contract = new Contract();
            PaymentType = new PaymentType();
            Type = new Type();
        }

        public int Id { get; set; }

        public ArticleChild.Article Article { get; set; }
    
        public int ArticleId { get; set; }

        public BudgetingGroup BudgetingGroup { get; set; }
    
        public int BudgetingGroupId { get; set; }

        public CounterPart CounterPart { get; set; }
    
        public int CounterPartId { get; set; }

        public PaymentInitiator PaymentInitiator { get; set; }
    
        public int PaymentInitiatorId { get; set; }

        public Cfo Cfo { get; set; }
    
        public int CfoId { get; set; }
    
        public decimal Sum { get; set; }

        public string Note { get; set; } = string.Empty;
    
        public int NumberEz { get; set; }

        public Project Project { get; set; }
    
        public int ProjectId { get; set; }

        public string IncomeExpense { get; set; } = string.Empty;

        public Firm Firm { get; set; }
    
        public int FirmId { get; set; }
    
        public int NumberSed { get; set; }

        public Place.Place Place { get; set; }
    
        public int PlaceId { get; set; }

        public Contract Contract { get; set; }
    
        public int ContractId { get; set; }
    
        public DateTime Period { get; set; }
    
        public PaymentType PaymentType { get; set; }
    
        public int PaymentTypeId { get; set; }
    
        public Type Type { get; set; }
    
        public int TypeId { get; set; }
    }
}
