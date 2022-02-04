using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        private OrderService _service;
        private Mock<IStorage> _storage;

        [SetUp]
        public void Setup()
        {
            _storage = new Mock<IStorage>();
            _service = new OrderService(_storage.Object);
            
        }
        
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var order = new Order();
            _service.PlaceOrder(order);
            
            _storage.Verify(s => s.Store(order));
        }

        [Test]
        public void PlaceOrder_WhenCalled_ReturnOrderId()
        {
            var order = new Order();

            var result = _service.PlaceOrder(order);
           
            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result, Is.TypeOf<int>());
           
        }
    }
}