using Microsoft.VisualStudio.TestTools.UnitTesting;
using DielectricConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DielectricConversion.Tests
{
    [TestClass()]
    public class DataProcessTests
    {
        public readonly static List<string> InputList = new List<string>
            {
                "Move relative (APT Y)",
                "<!--The table and data cluster are separated here--><Array>",
                "<Name></Name>",
                "<Dimsize>1</Dimsize>",
                "<Cluster>",
                "<Name>Macro Data Cluster</Name>",
                "<NumElts>15</NumElts>",
                "<U32>",
                "<Name>Task Number</Name>",
                "test task",
                "test task",
                "test task",
                "test task",
                "cut",
                "cut",
                "<Name>Task Number</Name>"
            };

        DataProcess dataProcess = new DataProcess(InputList);

        [TestMethod()]
        public void DataProcessTest()
        {
            //arrange
            string expected = "<Name>Task Number</Name>\ntest task\ntest task\ntest task";

            //act
            var actual = dataProcess.Process(InputList);

            //assert
            Assert.AreEqual(expected, actual[0]);
        }

        [TestMethod()]
        public void SplitTasksTest()
        {
            //arrange
            var taskSplits = new List<int>
            {
                5,9
            };
            string expected = "<Name>Macro Data Cluster</Name>";

            //act
            var actual = dataProcess.SplitTasks(InputList, taskSplits);            

            //Assert
            Assert.AreEqual(actual[0], expected);
        }

        [TestMethod()]
        public void SplitTasksTooShortTaskTest()
        {
            //arrange
            var taskSplits = new List<int>
            {
                5,7
            };
            string expected = "<Name>Macro Data Cluster</Name>";

            //act
            var actual = dataProcess.SplitTasks(InputList, taskSplits);

            //Assert
            Assert.AreEqual(actual[0], expected);
        }

        [TestMethod()]
        public void FindTaskSplitsTest()
        {
            //Arrange            
            var expectedOutput = new List<int>
            {
                8,15
            };

            //Act            
            IList<int> actual = dataProcess.FindTaskSplits(InputList);            

            //Assert
            Assert.AreEqual(actual[0], expectedOutput[0]);
            Assert.AreEqual(actual[1], expectedOutput[1]);
        }

        [TestMethod()]
        public void FindTaskSplitsNoTasksTest()
        {
            //Arrange
            InputList = new List<string>
            {

            };
            int expected = 0;

            //Act            
            IList<int> actual = dataProcess.FindTaskSplits(InputList);

            //Assert
            Assert.AreEqual(actual.Count, expected);
        }
    }
}