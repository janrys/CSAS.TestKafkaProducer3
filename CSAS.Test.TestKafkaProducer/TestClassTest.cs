using CSAS.TestKafkaProducer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSAS.Test.TestKafkaProducer
{
    [TestClass]
    public class TestClassTest
    {
        [TestMethod]
        public void GetNumberTest()
        {
            int anonymousNumber = 8;
            int anonymousMultiplier = 3;
            TestClass sut = new TestClass();
            Assert.AreEqual(anonymousNumber * anonymousMultiplier, sut.Multiply(anonymousNumber, anonymousMultiplier));

        }
    }
}
