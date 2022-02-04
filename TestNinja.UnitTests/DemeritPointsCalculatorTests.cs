using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void Setup()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void
            CalculateDemeritPoints_WhenSpeedIsLessThanOORSpeedIsHigherThanMaxSpeed_ReturnArgumentOutOfRangeException(
                int speed)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _demeritPointsCalculator.CalculateDemeritPoints(speed));
        }
        
        [Test]
        public void CalculateDemeritPoints_WhenSpeedIs80km_Return3()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(80);

            Assert.That(result, Is.EqualTo(3));
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(65)]
        [TestCase(66)]
        [TestCase(60)]
        public void CalculateDemeritPoints_WhenSpeedIsLessOREqualToSpeedLimit_Return0(int speed)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}