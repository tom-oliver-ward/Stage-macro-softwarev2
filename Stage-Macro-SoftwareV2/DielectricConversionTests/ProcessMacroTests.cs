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
    public class ProcessMacroTests
    {
        [TestMethod()]
        public void FindTaskSplitsTest()
        {
            //Arrange
            var InputList = new List<string>
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
                "<Name>Task Number</Name>"
            };
            var expectedOutput = new List<int>
            {
                8,10
            };

            //Act
            IList<int> actual = ProcessMacro.FindTaskSplits(InputList);

            //Assert
            Assert.AreEqual(actual[0], expectedOutput[0]);
        }

        [TestMethod()]
        public void FindTaskSplitsNoTasksTest()
        {
            //Arrange
            var InputList = new List<string>();
            int expected = 0;

            //Act
            var actual = ProcessMacro.FindTaskSplits(InputList);

            //Assert
            Assert.AreEqual(actual.Count, expected);
        }

        [TestMethod()]
        public void SplitTasksTest()
        {
            var taskSplits = new List<int>
            {
                5,10
            };
            var taskLength = 3;
            var rawData = new List<string>
            {
                "0","1","2","3","4","5","6","7","8","9","10","11","12","13"
            };
            var taskList = Enumerable.Range(0, taskSplits.Count)
                .Select(index => rawData.GetRange(taskSplits[index], taskLength))
                .ToList();

            Assert.AreEqual(0, 1);
        }
    }
}