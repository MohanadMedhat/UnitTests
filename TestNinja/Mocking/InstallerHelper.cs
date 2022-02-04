using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private IWebService _webService;
        private string _setupDestinationFile;
        
        public InstallerHelper(IWebService webService = null)
        {
            _webService = webService ?? new WebService();
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _webService.Downloader(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}