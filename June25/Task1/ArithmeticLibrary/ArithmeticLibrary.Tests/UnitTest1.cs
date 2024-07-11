using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ArithmeticLibrary.Tests
{
    [TestClass]
    public class ArithmeticTests
    {
        [TestMethod]
        public void AddTest()
        {
            Arithmetic arithmetic = new Arithmetic();
            Assert.AreEqual(arithmetic.Add(2,3) ,5);
        }

        [TestMethod]
        public void AddWithNullValus()
        {
            Arithmetic arithmetic = new Arithmetic();

            Assert.ThrowsException<ArgumentNullException>(()=>arithmetic.Add(2 , null));
        }
        [TestMethod]
        public void SubTest()
        {
            Arithmetic arithmetic = new Arithmetic();
            Assert.AreEqual(arithmetic.Subtract(2, 3), -1);
        }
        [TestMethod]
        public void SubWithNullValus()
        {
            Arithmetic arithmetic = new Arithmetic();

            Assert.ThrowsException<ArgumentNullException>(() => arithmetic.Subtract(2, null));
        }
        [TestMethod]
        public void MultiplyTest()
        {
            Arithmetic arithmetic = new Arithmetic();
            Assert.AreEqual(arithmetic.Multiply(2, 3), 6);
        }
        [TestMethod]
        public void MultiplyWithNullValus()
        {
            Arithmetic arithmetic = new Arithmetic();

            Assert.ThrowsException<ArgumentNullException>(() => arithmetic.Multiply(2, null));
        }
        [TestMethod]
        public void DivisionTest()
        {
            Arithmetic arithmetic = new Arithmetic();
            Assert.AreEqual(arithmetic.Divide(6, 3), 2);
        }
        [TestMethod]
        public void DivisionWithNullValus()
        {
            Arithmetic arithmetic = new Arithmetic();

            Assert.ThrowsException<ArgumentNullException>(() => arithmetic.Divide(2, null));
        }
    }
}
