using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;

namespace ConwaysTest
{
    [TestClass]
    public class TestCell
    {
        [TestMethod]
        public void CanCreateCell()
        {
            Cell newCell = new Cell();
            Assert.IsInstanceOfType(newCell, typeof(Cell));
        }
    }
}
