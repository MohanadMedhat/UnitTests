using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepo;


        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepo = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepo.Object);
        }
        
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();
            
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
        
        [Test]
        public void GetUnprocessedVideoAsCsv_AllVideosProcessed_ReturnListOfVideoIds()
        {
            IEnumerable<Video> listVideos = Enumerable.Empty<Video>();
            _videoRepo.Setup(vr => vr.GetUnprocessecedVideos()).Returns(listVideos);

            var result = _videoService.GetUnprocessedVideosAsCsv();
          
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetUnprocessedVideoAsCsv_WhenCalled_ReturnListOfVideoIds()
        {
            IEnumerable<Video> listVideos = new[]
            {
                new Video {Id = 1, Title = "1", IsProcessed = false},
                new Video {Id = 2, Title = "2", IsProcessed = false}
            };

            _videoRepo.Setup(vr => vr.GetUnprocessecedVideos()).Returns(listVideos);

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result, Is.EqualTo("1,2"));
          
        }

    }
}