namespace Models.Models.Dictionaries;

public class ArticleDictionary
{
    /// <summary>
    /// Id для служебных нужд
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///  Группа
    /// </summary>
    public string Group { get; set; } = string.Empty;

    /// <summary>
    ///  Статья исходник
    /// </summary>
    public string SourceArticle { get; set; } = string.Empty;

    /// <summary>
    ///  Наименование статьи исходника
    /// </summary>
    public string SourceArticleName { get; set; } = string.Empty;

    /// <summary>
    /// Правильная стоатья
    /// </summary>
    public string CorrectArticle { get; set; } = string.Empty;

    /// <summary>
    /// Правильное название статьи
    /// </summary>
    public string CorrectArticleName { get; set; } = string.Empty;

    /// <summary>
    /// Унифицированное назначение расхода
    /// </summary>
    public string PurposeOfExpenseName { get; set; } = string.Empty;

    /// <summary>
    /// Владелец расходов
    /// </summary>
    public string ExpenseOwnerName { get; set; } = string.Empty;

    /// <summary>
    /// Преобразование объекта в строчный формат
    /// </summary>
    /// <returns>Объект в виде строк(для тестов и тд)</returns>
    public override string ToString()
    {
        string result = string.Empty;

        result += $"id: {Id}\n";
        result += $"Group: {Group}\n";
        result += $"SourceArticleId: {SourceArticle}\n";
        result += $"SourceArticleName: {SourceArticleName}\n";
        result += $"CorrectArticleName: {CorrectArticleName}\n";
        result += $"PurposeOfExpenseName: {PurposeOfExpenseName}\n";
        result += $"ExpenseOwnerName: {ExpenseOwnerName}";

        return result;
    }
}