using Models.Models.Dictionaries;
using Models.Models.Input;

namespace DictionaryManager;

public interface IDictionaryManager
{
    /// <summary>
    /// Путь до dictionary article
    /// </summary>
    public string ArticleDictionaryPath { get; set; }

    /// <summary>
    /// Путь до dictionary places
    /// </summary>
    public string PlaceDictionaryPath { get; set; }

    /// <summary>
    /// Путь до dictionary cfo
    /// </summary>
    public string CfoDictionaryPath { get; set; }

    /// <summary>
    /// Считывает dictionary с файла и возвращает в виде списка
    /// </summary>
    /// <returns>Список dictionary articles</returns>
    public List<ArticleDictionary> GetArticleDictionary();

    /// <summary>
    /// Считывает dictionary с файла и возвращает в виде списка
    /// </summary>
    /// <returns>Список dictionary cfo</returns>
    public List<CfoDictionary> GetCfoDictionary();

    /// <summary>
    /// Считывает dictionary с файла и возвращает в виде списка
    /// </summary>
    /// <returns>Список dictionary places</returns>
    public List<PlaceDictionary> GetPlaceDictionaries();

    /// <summary>
    /// Обновляет dictionary приложения
    /// </summary>
    /// <param name="path">Путь до файла, котоырй будет распаршен</param>
    /// <returns>Путь до записанного файла</returns>
    public string WriteArticleDictionary(string path);

    /// <summary>
    /// Обновляет dictionary приложения
    /// </summary>
    /// <param name="path">Путь до файла, котоырй будет распаршен</param>
    /// <returns>Путь до записанного файла</returns>
    public string WriteCfoDictionary(string path);

    /// <summary>
    /// Обновляет dictionary приложения
    /// </summary>
    /// <param name="path">Путь до файла, котоырй будет распаршен</param>
    /// <returns>Путь до записанного файла</returns>
    public string WritePlaceDictionary(string path);
}