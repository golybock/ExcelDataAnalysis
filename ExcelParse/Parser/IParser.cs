namespace ExcelParse.Parser;

/// <summary>
/// Интерфейс для создания на его базе парсера
/// </summary>
/// <typeparam name="T">Тип данных возвращаемых реализацией интерфейса</typeparam>
public interface IParser<T>
{
    public void FindColumns();

    public List<T> Get();
}