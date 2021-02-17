using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text;

namespace Services
{
    public class HtmlPageToStringConverter : IHtmlPageToStringConverter
    {
        private readonly HtmlWeb webProdiver;

        public HtmlPageToStringConverter(HtmlWeb webProdiver)
        {
            if(webProdiver == null)
            {
                string message = "web provider is null";
                LoggerSingleton.instance.Value.WriteInLog(message);
                throw new ArgumentNullException(message);
            }

            this.webProdiver = webProdiver;
        }

        public string Convert(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                LoggerSingleton.instance.Value.WriteInLog("url is null");
                return null;
            }
            HtmlDocument document;

            try
            {
                document = webProdiver.Load(url);
            }
            catch (Exception ex)
            {
                LoggerSingleton.instance.Value.WriteInLog(ex.Message);
                return null;
            }

            document.DocumentNode.Descendants()
                .Where(n => n.Name == "script" || n.Name == "style")
                .ToList()
                .ForEach(n => n.Remove());

            HtmlNode root = document.DocumentNode;
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
