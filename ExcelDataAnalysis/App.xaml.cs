using System;
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
        private static string BasePath =>
            $"C://Users/{Environment.UserName}/Documents/ExcelDataAnalysis";

        private static string DictionariesPath =>
            BasePath + "/Dictionaries";

        public static string ArchivePath =>
            BasePath + "/Archive";

        public static string ArticleDictionary =>
            DictionariesPath + "/ArticlesDictionary.json";

        public static string CfoDictionary =>
            DictionariesPath + "/CfoDictionary.json";

        public static string PlacesDictionary =>
            DictionariesPath + "/PlacesDictionary.json";

        private static string _appSettings =>
            "appsettings.json";

        public static AppSettings? AppSettings =>
            ReadAppSettings();

        private bool SettingsExists() =>
            File.Exists(_appSettings);

        private bool DictionariesExists() =>
            File.Exists(DictionariesPath);

        public static async Task SaveSettingsAsync(AppSettings appSettings) =>
            await WriteAppSettingsAsync(appSettings);

        public static void SaveSettings(AppSettings appSettings) =>
            WriteAppSettings(appSettings);

        private static AppSettings DefaultSettings => new AppSettings()
        {
            ArticlesDictionaryPath = $"{ArticleDictionary}",
            CfoDictionaryPath = $"{CfoDictionary}",
            PlacesDictionaryPath = $"{PlacesDictionary}",
            SupportEmail = "danila.arschinov@yandex.ru",
            Version = "1.0b"
        };

        private static AppSettings? ReadAppSettings()
        {
            using StreamReader sr = new StreamReader(_appSettings);

            string json = sr.ReadToEnd();

            return JsonSerializer.Deserialize<AppSettings>(json);
        }

        private static async Task<AppSettings?> ReadAppSettingsAsync()
        {
            using StreamReader sr = new StreamReader(_appSettings);

            return await JsonSerializer.DeserializeAsync<AppSettings>(sr.BaseStream);
        }

        private static async Task WriteAppSettingsAsync(AppSettings appSettings)
        {
            await using StreamWriter sw = new StreamWriter(_appSettings);

            var options = new JsonSerializerOptions
            {
                Encoder =
                    JavaScriptEncoder.Create(
                        UnicodeRanges.BasicLatin,
                        UnicodeRanges.Cyrillic
                    ),
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(appSettings, options);

            await sw.WriteAsync(json);
        }

        private static void WriteAppSettings(AppSettings appSettings)
        {
            using StreamWriter sw = new StreamWriter(_appSettings);

            var options = new JsonSerializerOptions
            {
                Encoder =
                    JavaScriptEncoder.Create(
                        UnicodeRanges.BasicLatin,
                        UnicodeRanges.Cyrillic
                    ),
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(appSettings, options);

            sw.WriteAsync(json);
        }
        
        public static void RestoreAppSettings()
        {
            WriteAppSettings(DefaultSettings);
        }

        private void CreateDirsIfNotExists()
        {
            CreateDirIfNotExists(BasePath);

            CreateDirIfNotExists(ArchivePath);

            CreateDirIfNotExists(DictionariesPath);
        }

        private void CreateDirIfNotExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void CreateDictionariesIfNotExists()
        {
            CreateDictionaryIfNotExists(PlacesDictionary);

            CreateDictionaryIfNotExists(CfoDictionary);

            CreateDictionaryIfNotExists(ArticleDictionary);
        }

        private void CreateDictionaryIfNotExists(string path)
        {
            if (!File.Exists(path))
                File.Create(path);
        }

        private void CreateAppSettingsIfNotExists()
        {
            if (!SettingsExists())
                WriteAppSettings(DefaultSettings);
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            CreateAppSettingsIfNotExists();

            CreateDirsIfNotExists();

            CreateDictionariesIfNotExists();
        }
    }
}