using System.Collections.Generic;
using System.Linq;
using System.Net;



namespace TestNinja.Mocking
{
    public interface IWebService
    {
        void Downloader(string url, string path);
    }

    public class WebService : IWebService
    {
        public void Downloader(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}