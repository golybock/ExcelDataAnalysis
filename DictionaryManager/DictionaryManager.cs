using Models.Models.Dictionaries;

namespace DictionaryManager;

public class DictionaryManager : IDictionaryManager
{
    private DictionaryWriter _dictionaryWriter = new DictionaryWriter();
    
    public string ArticleDictionaryPath { get; set; } = "Dictionaries/articlesDictionary.json";
    public string PlaceDictionaryPath { get; set; } = "Dictionaries/placesDictionary.json";
    public string CfoDictionaryPath { get; set; } = "Dictionaries/cfoDictionary.json";
    
    public List<ArticleDictionary> GetArticleDictionary()
    {
        throw new NotImplementedException();
    }

    public List<CfoDictionary> GetCfoDictionary()
    {
        throw new NotImplementedException();
    }

    public List<PlaceDictionary> GetPlaceDictionaries()
    {
        throw new NotImplementedException();
    }

    public string WriteArticleDictionary(string path)
    {
        throw new NotImplementedException();
    }

    public string WriteCfoDictionary(string path)
    {
        throw new NotImplementedException();
    }

    public string WritePlaceDictionary(string path)
    {
        throw new NotImplementedException();
    }
}