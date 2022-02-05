using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _controller;
        private Mock<IEmployeeStorage> _storage;
        private Mock<IEmployeeRedirect> _redirect;

        [SetUp]
        public void Setup()
        {
            _storage = new Mock<IEmployeeStorage>();
            _redirect = new Mock<IEmployeeRedirect>();
            _controller = new EmployeeController(_storage.Object, _redirect.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            _controller.DeleteEmployee(1);

            _storage.Verify(s => s.DeleteEmployee(1));

            Assert.IsInstanceOf<RedirectResult>(_controller.DeleteEmployee(1));
        }

    }
}