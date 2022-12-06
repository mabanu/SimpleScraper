// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using HtmlAgilityPack;
using SimpleScraper;

Console.WriteLine("Hello, World!");

HtmlWeb web = new HtmlWeb();
HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/Greece");

var HeaderNames = doc.DocumentNode.SelectNodes("//span[@class='toctext']");

var titles = new List<Row>();
foreach (var item in HeaderNames)
{
	titles.Add(new Row { Title = item.InnerText});
}
using (var writer = new StreamWriter("SimpleScraper/scrapedata.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
	csv.WriteRecords(titles);
}