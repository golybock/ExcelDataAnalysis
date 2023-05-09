using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Models.Models.Dictionaries;

namespace DictionaryManager;

public class DictionaryWriter
{
    public async Task WriteCfoDictionary(List<CfoDictionary> cfos)
    {
        throw new NotImplementedException();
        
        string path = "";
        
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

        if (path != null)
        {
            await using StreamWriter sw = new StreamWriter(path);

            await sw.WriteLineAsync(jsonCfos);
        }
    }
}