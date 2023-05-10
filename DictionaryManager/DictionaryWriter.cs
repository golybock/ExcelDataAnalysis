using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Models.Models.Dictionaries;
using Models.Models.Input;

namespace DictionaryManager;

public class DictionaryWriter
{
    public async Task WriteCfoDictionary(List<CfoDictionary> cfos, string path)
    {
        // string path = "Dictionaries/cfoDictionary.json";
        
        var options = new JsonSerializerOptions
        {
            Encoder =
                JavaScriptEncoder.Create(
                    UnicodeRanges.BasicLatin,
                    UnicodeRanges.Cyrillic
                ),
            WriteIndented = true
        };

        string jsonCfos = JsonSerializer.Serialize(cfos, options);

        await using StreamWriter sw = new StreamWriter(path);

        await sw.WriteLineAsync(jsonCfos);
    }
    
    public async Task WritePlaceDictionary(List<PlaceDictionary> places, string path)
    {
        // string path = "Dictionaries/placesDictionary.json";
        
        var options = new JsonSerializerOptions
        {
            Encoder =
                JavaScriptEncoder.Create(
                    UnicodeRanges.BasicLatin,
                    UnicodeRanges.Cyrillic
                ),
            WriteIndented = true
        };

        string jsonPlaces = JsonSerializer.Serialize(places, options);

        await using StreamWriter sw = new StreamWriter(path);

        await sw.WriteLineAsync(jsonPlaces);
    }
    
    public async Task WriteArticleDictionary(List<ArticleDictionary> articles, string path)
    {
        // string path = "Dictionaries/articlesDictionary.json";
        
        var options = new JsonSerializerOptions
        {
            Encoder =
                JavaScriptEncoder.Create(
                    UnicodeRanges.BasicLatin,
                    UnicodeRanges.Cyrillic
                ),
            WriteIndented = true
        };

        string jsonPlaces = JsonSerializer.Serialize(articles, options);

        await using StreamWriter sw = new StreamWriter(path);

        await sw.WriteLineAsync(jsonPlaces);
    }
}