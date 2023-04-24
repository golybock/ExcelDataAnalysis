using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using ExcelDataAnalysis.Models.Settings;

namespace ExcelDataAnalysis
{
    public partial class App : Application
    {
        public static AppSettings DefaultSettings => new AppSettings()
        {
            ArticlesDictionaryPath = "/ArtcilesDictionary.json",
            CfoDictionaryPath = "/CfoDictionary.json",
            CountPlacesDictionaryPath = "/PlacesDictionary.json"
        };
        
        public static async Task<AppSettings?> ReadAppSettings()
        {
            string path = "appsettings.json";

            using StreamReader sr = new StreamReader(path);
            
            return await JsonSerializer.DeserializeAsync<AppSettings>(sr.BaseStream);
        }
        
        public static async Task WriteAppSettings(AppSettings appSettings)
        {
            string path = "appsettings.json";

            await using StreamWriter sw = new StreamWriter(path);

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            
            string json = JsonSerializer.Serialize(appSettings, options);

            await sw.WriteAsync(json);
        }

        private bool SettingsExists() =>
            File.Exists("appsettings.json");

        private async void App_OnStartup(object sender, StartupEventArgs e)
        {
            if(!SettingsExists())
                await WriteAppSettings(DefaultSettings);
        }
    }
}