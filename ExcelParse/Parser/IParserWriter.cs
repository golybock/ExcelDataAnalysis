using ArticlesInput = Models.Models.Input.Article;

namespace ExcelParse.Parser;

/// <summary>
/// Доп интерфейс для дополнения интерфейса IParserReader методом записи
/// </summary>
/// <typeparam name="T">Тип данных возвращаемых реализацией интерфейса</typeparam>
public interface IParserWriter<T>
{
    /// <summary>
    /// Метод для записи итоговых данных в файл
    /// </summary>
    /// <param name="articles">Метод созданный для </param>
    /// <returns>Возвращает путь до созданного файла</returns>
    public string Write(List<ArticlesInput> articles);
}