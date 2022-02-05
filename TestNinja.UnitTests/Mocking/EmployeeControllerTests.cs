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

        [SetUp]
        public void Setup()
        {
            _storage = new Mock<IEmployeeStorage>();
            _controller = new EmployeeController(_storage.Object);
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