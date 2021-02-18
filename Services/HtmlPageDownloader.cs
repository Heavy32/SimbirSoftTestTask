using System.IO;
using System;
using HtmlAgilityPack;

namespace Services
{
    public class HtmlPageDownloader : IHtmlPageDownloader
    {
        private readonly HtmlDocument webPage;

        public HtmlPageDownloader(HtmlDocument webPage)
        {
            if (webPage == null)
            {
                string message = "web page is empty";
                LoggerSingleton.instance.Value.WriteInLog(message);
                throw new ArgumentNullException(message);
            }
            this.webPage = webPage;
        }

        public void Download(string path)
        {
            try
            {
                File.WriteAllText(path, webPage.Text);
            }
            catch (Exception ex)
            {
                LoggerSingleton.instance.Value.WriteInLog(ex.Message);
                return;
            }
        }
    }
}
