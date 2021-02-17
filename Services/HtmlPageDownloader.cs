using System.IO;
using System;

namespace Services
{
    public class HtmlPageDownloader : IHtmlPageDownloader
    {
        private readonly string path;
        private readonly HtmlPageToStringConverter converter;

        public HtmlPageDownloader(string path, HtmlPageToStringConverter converter)
        {
            if (string.IsNullOrEmpty(path))
            {
                string message = "path is empty";
                LoggerSingleton.instance.Value.WriteInLog(message);
                throw new ArgumentNullException(message);
            }

            if (converter == null)
            {
                string message = "converter is null";
                LoggerSingleton.instance.Value.WriteInLog(message);
                throw new ArgumentNullException(message);
            }

            this.path = path;
            this.converter = converter;
        }

        public void Download(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                LoggerSingleton.instance.Value.WriteInLog("url is empty");
                return;
            }

            try
            {
                File.WriteAllText(path, converter.Convert(url));
            }
            catch (Exception ex)
            {
                LoggerSingleton.instance.Value.WriteInLog(ex.Message);
                return;
            }
        }
    }
}
