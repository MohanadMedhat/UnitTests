using System.Net;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;


namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper _sut;
        private Mock<IWebService> _webService;

        [SetUp]
        public void Setup()
        {
            _webService = new Mock<IWebService>();
            _sut = new InstallerHelper(_webService.Object);
        }

        [Test]
        public void DownloadInstaller_NoException_ReturnsTrue()
        {
            var result = _sut.DownloadInstaller("", "");
            
            Assert.That(result, Is.EqualTo(true));
        }
        
        [Test]
        public void DownloadInstaller_ExceptionOccurs_ReturnsWebException()
        {
            _webService.Setup(ws => ws.Downloader(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _sut.DownloadInstaller("customerName","InstallerName");
            
            _webService.Verify(ws => ws.Downloader(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.That(result, Is.EqualTo(false));
           
        }
                
    }
}