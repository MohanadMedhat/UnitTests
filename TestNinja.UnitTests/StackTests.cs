using System;
using System.Collections;
using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<object> _stack;
        
            [SetUp]
        public void Setup()
        {
            _stack = new Stack<object>();
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Push_ObjectIsNull_ReturnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stack.Push(null));
        }

        [Test]
        public void Push_ObjectIsNotNull_AddObject()
        {
            _stack.Push(1);
            
            Assert.That(_stack.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Pop_ListIsEmpty_ReturnInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }
        
        [Test]
        public void Pop_ListIsNotEmpty_ReturnLastElementAndRemoveIt()
        {
            _stack.Push(1);
            _stack.Push(2);
            
            Assert.That(_stack.Pop(), Is.EqualTo(2));
            Assert.That(_stack.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Peek_ListIsEmpty_ReturnInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Peek());
        }
        
        [Test]
        public void Peek_ListIsNotEmpty_ReturnLastElement()
        {
            _stack.Push(1);
            _stack.Push(2);
            
            Assert.That(_stack.Peek(), Is.EqualTo(2));
            Assert.That(_stack.Count, Is.EqualTo(2));
        }
    }
    
    
}