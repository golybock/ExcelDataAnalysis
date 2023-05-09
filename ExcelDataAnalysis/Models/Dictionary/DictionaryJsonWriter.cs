using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Models.Models.Dictionaries;

namespace ExcelDataAnalysis.Models.Dictionary;

public class DictionaryJsonWriter
{
    public async Task WriteCfoDictionary(List<CfoDictionary> cfos)
    {
        string? path = App.AppSettings?.CfoDictionaryPath;

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
    
    // public async Task WriteArticleDictionary(List<Article> articles)
    // {
    //     string? path = App.AppSettings?.CfoDictionaryPath;
    //
    //     var options = new JsonSerializerOptions
    //     {
    //         Encoder =
    //             JavaScriptEncoder.Create(
    //                 UnicodeRanges.BasicLatin,
    //                 UnicodeRanges.Cyrillic
    //             ),
    //         WriteIndented = true
    //     };
    //
    //     string jsonCfos = JsonSerializer.Serialize(cfos, options);
    //
    //     if (path != null)
    //     {
    //         await using StreamWriter sw = new StreamWriter(path);
    //
    //         await sw.WriteLineAsync(jsonCfos);
    //     }
    // }
}