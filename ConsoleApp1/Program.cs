using ExcelParse.Parser;
using ExcelParse.Parser.Article;
using ExcelParse.Parser.Cfo;

var CfoParser = new CfoParser(@"C:\Users\arshi\RiderProjects\ExcelDataAnalysis\files\Классификация ЦФО.xlsx");
var ArticleParser = new ArticleParser(@"C:\Users\arshi\RiderProjects\ExcelDataAnalysis\files\Статья и наименование статьи.xlsx");
var placeParser = new PlaceParser(@"C:\Users\arshi\RiderProjects\ExcelDataAnalysis\files\Количество типов площадей.xlsx");

CfoParser.Get();
Console.WriteLine();
ArticleParser.Get();
Console.WriteLine();
placeParser.Get();