using DataBaseProvider;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services;
using Services.FilterDecorator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ConsolePresentation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await DbSetUp();

            Console.WriteLine("Please enter a web site, example: www.simbirsoft.com");
            string host = Console.ReadLine().ToLower();

            Console.WriteLine("What would you like to do? \n 1) Get statistic and save it to database \n 2) download web page to .txt file? \n 3) Finish work");
            
            string command = Console.ReadLine().ToLower();
            while(command != "3")
            {
                var webProvider = new HtmlWeb();
                HtmlDocument webPage = webProvider.Load("https://" + host);

                if (command == "1")
                {
                    await GetStatisticAndSaveToDbAsync(webPage, host);
                }
                else if (command == "2")
                {
                    Download(webPage, host);
                }
                else if (command == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Command is not available");
                }

                Console.WriteLine("What would you like to do? \n 1) Get statistic and save it to database \n 2) download web page to .txt file? \n 3) Finish work");
                command = Console.ReadLine();
            }
        }

        private static string GetConnectionString()
        {
            using (StreamReader file = File.OpenText(@"../../../Settings.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                return o2.Value<string>("Connection");
            }
        }

        private async static Task DbSetUp()
        {
            
            DataBaseSetUp dataBase = new DataBaseSetUp(GetConnectionString());
            await dataBase.DataBaseSetUpAsync();
        }

        private static void Download(HtmlDocument webPage, string host)
        {
            var downloader = new HtmlPageDownloader(webPage);
            downloader.Download(host + ".txt");
        }

        private static async Task GetStatisticAndSaveToDbAsync(HtmlDocument webPage, string host)
        {
            Console.WriteLine("wait...");
            var converter = new HtmlPageToStringConverter(webPage);
            string text = converter.Convert();

            char[] pattern = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t', '–', '-', '/' };

            IEnumerable<string> words =
                new OnlyWordsFilterDecorator(
                    new SplitStringByPatternFilter(text, pattern))
                .Filter();

            var statisticProvider = new StatisticProvider();
            Dictionary<string, int> statistic = statisticProvider.GetWordsCount(words);

            foreach (var item in statistic)
            {
                System.Console.WriteLine(item);
            }

            var saveStatistic = new SaveStatisticToDataBase(new StatisticRepository(GetConnectionString()));
            await saveStatistic.Save(statistic, host);
        }
    }
}
