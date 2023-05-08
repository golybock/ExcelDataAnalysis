namespace Models.Models.Output;

public class Output
{
    /// <summary>
    /// Id для служебных нужд
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Дата оплаты
    /// </summary>
    public DateTime DateOfPayment { get; set; }

    /// <summary>
    /// Статья
    /// </summary>
    public string? Article { get; set; }

    /// <summary>
    /// Наименование статьи
    /// </summary>
    public string? ArticleName { get; set; }

    /// <summary>
    /// Код группы бюджетирования
    /// </summary>
    public string? BudgetGroupCode { get; set; }

    /// <summary>
    /// Контрагет
    /// </summary>
    public string? PartnerNumber { get; set; }

    /// <summary>
    /// Наименование контрагента
    /// </summary>
    public string? PartnerName { get; set; }

    /// <summary>
    /// Инициализатор платежа
    /// </summary>
    public string? PaymentInitiatorCode { get; set; }

    /// <summary>
    /// Наименование инициализатора платежа
    /// </summary>
    public string? PaymentInitiatorName { get; set; }

    /// <summary>
    /// ЦФО
    /// </summary>
    public string? Cfo { get; set; }

    /// <summary>
    /// Наименование ЦФО
    /// </summary>
    public string? CfoName { get; set; }

    /// <summary>
    /// ЦФУ
    /// </summary>
    public string? Cfu { get; set; }

    /// <summary>
    /// Наименование ЦФУ
    /// </summary>
    public string? CfuName { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Sum { get; set; }

    /// <summary>
    /// Примечанеие по документации
    /// </summary>
    public string? NoteOfDocuments { get; set; }

    /// <summary>
    /// Унифицированное назначение расхода
    /// </summary>
    public string? UnifiedExpenseAssignment { get; set; }

    /// <summary>
    /// Номер ЭЗ
    /// </summary>
    public string? NumberEz { get; set; }

    /// <summary>
    /// Тип оплаты
    /// </summary>
    public string? PaymentType { get; set; }

    /// <summary>
    /// Код проекта
    /// </summary>
    public string? ProjectCode { get; set; }

    /// <summary>
    /// Наименование проекта
    /// </summary>
    public string? ProjectName { get; set; }

    /// <summary>
    /// Приход-расход
    /// </summary>
    public string? IncomeExpense { get; set; }

    /// <summary>
    /// Фирма
    /// </summary>
    public string? Firm { get; set; }

    /// <summary>
    /// Номер заявки СЭД
    /// </summary>
    public string? ApplicationNumberSed { get; set; }

    /// <summary>
    /// Название региона
    /// </summary>
    public string? RegionName { get; set; }

    /// <summary>
    /// Название бизнес региона
    /// </summary>
    public string? BusinessRegionName { get; set; }

    /// <summary>
    /// ЦФО верхнего уровня
    /// </summary>
    public string? UpperCfo { get; set; }

    /// <summary>
    /// Наименование ЦФО верхнего уровня
    /// </summary>
    public string? UpperCfoName { get; set; }

    /// <summary>
    /// Id договора
    /// </summary>
    public string? ContractId { get; set; }

    /// <summary>
    /// Номер договора
    /// </summary>
    public string? ContractNumber { get; set; }

    /// <summary>
    /// Код отдела договора
    /// </summary>
    public string? DivisionContractCode { get; set; }

    /// <summary>
    /// Цфо для плана
    /// </summary>
    public string? CfoForPlan { get; set; }

    /// <summary>
    /// Период
    /// </summary>
    public string? Period { get; set; }

    /// <summary>
    /// Объект недвижимости
    /// </summary>
    public string? PlaceObject { get; set; }

    /// <summary>
    /// Тип записи
    /// </summary>
    public string? RecordType { get; set; }

    /// <summary>
    /// Владелец расходов
    /// </summary>
    public string? ExpenseOwner { get; set; }

    /// <summary>
    /// Тип площади
    /// </summary>
    public string? SquareType { get; set; }

    /// <summary>
    /// Тип объекта
    /// </summary>
    public string? ObjectType { get; set; }

    /// <summary>
    /// Кол-во показателя
    /// </summary>
    public string? CountOfIndicator { get; set; }

    /// <summary>
    /// Еденица измерения
    /// </summary>
    public string? Unit { get; set; }

    /// <summary>
    /// Статус площади объекта
    /// </summary>
    public string? StatusPlaceSquare { get; set; }
}