using ExcelParse.Parser;
using ExcelParse.Parser.Article;
using ExcelParse.Parser.Cfo;

var CfoParser = new CfoParser(@"C:\Coding\C#\ExcelDataAnalysis\Files\Классификация ЦФО.xlsx");
var ArticleParser = new ArticleParser(@"C:\Coding\C#\ExcelDataAnalysis\Files\Статья и наименование статьи.xlsx");
var placeParser = new PlaceParser(@"C:\Coding\C#\ExcelDataAnalysis\Files\Количество типов площадей.xlsx");

CfoParser.Get();
Console.WriteLine();
ArticleParser.Get();
Console.WriteLine();
placeParser.Get();