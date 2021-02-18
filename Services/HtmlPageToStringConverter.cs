using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text;

namespace Services
{
    public class HtmlPageToStringConverter : IHtmlPageToStringConverter
    {
        private readonly HtmlDocument webPage;

        public HtmlPageToStringConverter(HtmlDocument webPage)
        {
            if(webPage == null)
            {
                string message = "web provider is null";
                LoggerSingleton.instance.Value.WriteInLog(message);
                throw new ArgumentNullException(message);
            }

            this.webPage = webPage;
        }

        public string Convert()
        {
            webPage.DocumentNode.Descendants()
                .Where(n => n.Name == "script" || n.Name == "style")
                .ToList()
                .ForEach(n => n.Remove());

            HtmlNode root = webPage.DocumentNode;
            var sb = new StringBuilder();
            foreach (var node in root.DescendantsAndSelf())
            {
                if (!node.HasChildNodes)
                {
                    string text = node.InnerText;
                    if (!string.IsNullOrEmpty(text))
                        sb.AppendLine(text.Trim().ToLower());
                }
            }

            return sb.ToString();
        }
    }
}
