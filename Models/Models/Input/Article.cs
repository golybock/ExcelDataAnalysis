namespace Models.Models.Input;

public class Article
{
    /// <summary>
    /// Id для служебных нужд
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Период, берется из заголовка файла списания
    /// </summary>
    public string Period { get; set; } = string.Empty;

    /// <summary>
    /// ЦФУ (Код)
    /// </summary>
    public string Cfu { get; set; } = string.Empty;

    /// <summary>
    /// Наименование ЦФУ
    /// </summary>
    public string CfuName { get; set; } = string.Empty;

    /// <summary>
    /// Вышестоящий ЦФО (Код)
    /// </summary>
    public string UpperCfo { get; set; } = string.Empty;

    /// <summary>
    /// Причина списания (Код)
    /// </summary>
    public string ReasonOfWriteOff { get; set; } = string.Empty;

    /// <summary>
    /// Наименование причины списания
    /// </summary>
    public string ReasonOfWriteOffName { get; set; } = string.Empty;

    /// <summary>
    /// Проект
    /// </summary>
    public string Project { get; set; } = string.Empty;

    /// <summary>
    /// Название проекта
    /// </summary>
    public string ProjectName { get; set; } = string.Empty;

    /// <summary>
    /// Сумма (руб)
    /// </summary>
    public decimal Sum { get; set; }

    /// <summary>
    /// Себестоимость (руб)
    /// </summary>
    public decimal CostPrice { get; set; }

    /// <summary>
    /// Себестоимость (usd) вроде
    /// </summary>
    public decimal CostPriceUsd { get; set; }

    /// <summary>
    /// Счет (код)
    /// </summary>
    public string Check { get; set; } = string.Empty;

    /// <summary>
    /// Наименование счета
    /// </summary>
    public string CheckName { get; set; } = string.Empty;

    /// <summary>
    /// Код производства
    /// </summary>
    public string FactoryCode { get; set; } = string.Empty;

    /// <summary>
    /// Наименование участка
    /// </summary>
    public string AreaName { get; set; } = string.Empty;
}