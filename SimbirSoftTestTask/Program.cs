using HtmlAgilityPack;
using Services;
using Services.FilterDecorator;
using System.Collections.Generic;

namespace SimbirSoftTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb webProvider = new HtmlWeb();
            HtmlPageToStringConverter converter = new HtmlPageToStringConverter(webProvider);
            string text = converter.Convert("https://www.simbirsoft.com/");

            char[] pattern = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t', '–', '-', '/' };

            IEnumerable<string> words =
                new OnlyWordsFilterDecorator(
                    new SplitStringByPatternFilter(text, pattern))
                .Filter();

            var statisticProvider = new StatisticProvider();
            var t = statisticProvider.GetWordsCount(words);

            foreach (var item in t)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
