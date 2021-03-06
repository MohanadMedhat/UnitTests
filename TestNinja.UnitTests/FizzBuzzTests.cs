using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {

        [Test]
        public void GetOutput_WhenNumberIsDivisibleBy5AND3_ReturnFizzBuzz()
        {
           var result = FizzBuzz.GetOutput(15);
           
           Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
        
        [Test]
        public void GetOutput_WhenNumberIsDivisibleBy3_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);
           
            Assert.That(result, Is.EqualTo("Fizz"));
        }
        
        [Test]
        public void GetOutput_WhenNumberIsDivisibleBy5_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);
           
            Assert.That(result, Is.EqualTo("Buzz"));
        }
        
        [Test]
        public void GetOutput_WhenNumberIsNotDivisibleBy5AND3_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(23);
           
            Assert.That(result, Is.EqualTo("23"));
        }
        
    }
}