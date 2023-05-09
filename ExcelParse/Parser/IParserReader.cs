namespace ExcelParse.Parser;

/// <summary>
/// Интерфейс для создания на его базе парсера
/// </summary>
/// <typeparam name="T">Тип данных возвращаемых реализацией интерфейса</typeparam>
public interface IParserReader<T>
{
    /// <summary>
    /// Скорость выполнения алгоритма - O(n^2)
    /// </summary>
    /// <exception cref="Exception">
    /// 
    /// 1. Ошибка при отсутствии доступа к файлу либо внутренняя ошибка библиотеки
    ///
    /// 2. Какая-то из ячеек не найдена - вызывается исключение с уведомлением
    /// 
    /// </exception>
    public void FindColumns();

    /// <summary>
    /// Основной метод класса для парсинга файла, вызываемых в других классах
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception">
    ///
    /// 1. Ошибка при отсутствии доступа к файлу либо внутренняя ошибка библиотеки
    ///
    /// 2. Исключение в методе FindColumns
    /// 
    /// </exception>
    public List<T> Get();
}