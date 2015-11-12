using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
using System.Collections.Generic;

namespace ConwaysTest
{
    [TestClass]
    public class TestWorld
    {
        [TestMethod]
        public void CanCreateWorld()
        {
            World  world = new World();
            Assert.IsInstanceOfType(world, typeof(World));
        }

        [TestMethod]
        public void AddCellTest()
        {
            int x = 0;
            int y = 0;
            World world = new World();
            world.AddCell(x, y);
            Assert.AreEqual(x, world.Cells[0].X);
            Assert.AreEqual(y, world.Cells[0].Y);
        }

        [TestMethod]
        public void CountWithNoCells()
        {
            World world = new World();
            int expected = 0;
            Assert.AreEqual(expected, world.Count());
        }

        [TestMethod]
        public void CountWithOneCell()
        {
            int x = 0;
            int y = 0;
            World world = new World();
            world.AddCell(x, y);
            world.Count();
            int expected = 1;
            Assert.AreEqual(expected, world.Count());
        }

        [TestMethod]
        public void ReturnCellAtSpecificPosition()
        {
            int x = 0;
            int y = 1;
            int expectedX = 0;
            int expectedY = 1;
            World world = new World();
            world.AddCell(x, y);
            Cell actual = world.GetCell(0,1);
            Assert.AreEqual(expectedX, actual.X);
            Assert.AreEqual(expectedY, actual.Y);
        }

        [TestMethod]
        public void RemoveCellAtSpecificPosition()
        {
            int x = 0;
            int y = 1;
            World world = new World();
            world.AddCell(x, y);;
            world.RemoveCell(x, y);
            Assert.AreEqual(null, world.GetCell(0,1));
        }

        [TestMethod]
        public void GetLiveNeighborsTest()
        {
            Cell newCell = new Cell { X = 0, Y = 0 };
            Cell anotherCell = new Cell { X = 1, Y = 0 };
            World world = new World();
            world.AddCell(0, 0);
            world.AddCell(0,1);
            world.AddCell(2,3);
            world.AddCell(-1, -1);
            List<Cell>actual = world.GetLiveNeighbors(world.GetCell(0,0).X, world.GetCell(0, 0).Y);
            
            Assert.AreEqual(2,actual.Count);
        }

        [TestMethod]
        public void NumLiveNeighborsTest()
        {
            World world = new World();
            world.AddCell(0, 0);
            world.AddCell(0, 1);
            world.AddCell(2, 3);
            world.AddCell(-1, -1);

            Assert.AreEqual(1, world.NumLiveNeighbors(0, 1));
            Assert.AreEqual(2, world.NumLiveNeighbors(0, 0));
        }

        [TestMethod]
        public void DeathRule()
        {
            World world = new World();
            world.AddCell(0, 0);
            world.AddCell(0, 1);
            world.AddCell(-1, -1);
            Assert.AreEqual(3, world.Count());
            List<Cell> actual= world.AngelOfDeath();
            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public void LifeRuleWithOneNewCell()
        {
            World world = new World();
            world.AddCell(0, 0);
            world.AddCell(-1, 0);
            world.AddCell(0, 1);
            Assert.AreEqual(3, world.Count());
            List<Cell> expectedWithDuplicates = world.ActOfGod();
            Assert.AreEqual(3, expectedWithDuplicates.Count);
        }

        [TestMethod]
        public void LifeRuleWithTwoNewCells()
        {
            World world = new World();
            world.AddCell(0, 0);
            world.AddCell(0, 1);
            world.AddCell(0, -1);
            Assert.AreEqual(3, world.Count());
            List<Cell> listWithDupilicatesOfNewCells = world.ActOfGod();
            Assert.AreEqual(6, listWithDupilicatesOfNewCells.Count);
        }

        [TestMethod]
        public void JudgmentOfGodAddsToCellsAndIgnoresDuplicates()
        {
            World world = new World();
            world.AddCell(0, 0);
            world.AddCell(0, 1);
            world.AddCell(0, -1);
            Assert.AreEqual(3, world.Count());
            world.JudgmentOfGod();
            Assert.IsNotNull(world.GetCell(0,0));
            Assert.IsNotNull(world.GetCell(1, 0));
            Assert.IsNotNull(world.GetCell(-1, 0));
            Assert.AreEqual(3, world.Count());
        }

        [TestMethod]
        public void AngelOfDeathPulsar()
        {
            World world = new World();
            world.AddCell(0, 0);
            world.AddCell(0, 1);
            world.AddCell(0, -1);
            world.AngelOfDeath();
            Assert.IsNotNull(world.GetCell(0,0));
        }
    }
}
