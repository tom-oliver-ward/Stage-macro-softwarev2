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
    public class DataFormatTests
    {
        //out of range means either task length is too small or list is empty
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
                "<Name>Task Number</Name>",
                "cut",
                "cut",
            };

        DataFormat dataProcess = new DataFormat(InputList);

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
            Assert.AreEqual(expected, actual[0]);
        }

        [TestMethod()]
        public void SplitTasksTestNoTask()
        {
            //arrange
            var taskSplits = new List<int>
            {
            };
            var expected = new List<string>();

            //act
            //var actual = dataProcess.SplitTasks(InputList, taskSplits);

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dataProcess.SplitTasks(InputList, taskSplits));
        }

        [TestMethod()]
        public void SplitTasksTestOneTask()
        {
            //arrange
            var taskSplits = new List<int>
            {
                8
            };
            var expected = "<Name>Task Number</Name>\ntest task\ntest task\ntest task\ntest task\ncut\ncut";

            //act
            var actual = dataProcess.SplitTasks(InputList, taskSplits);

            //Assert
            Assert.AreEqual(expected, actual[0]);
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
        public void FindTaskSplitsEmptyTest()
        {
            //Arrange
            var InputListEmpty = new List<string>
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
                "cut"                
            };
            int expected = 8;

            //Act            
            IList<int> actual = dataProcess.FindTaskSplits(InputListEmpty);

            //Assert
            Assert.AreEqual(expected, actual[0]);
        }

        [TestMethod()]
        public void FindTaskSplitsSingleTaskTest()
        {
            //Arrange
            var InputListEmpty = new List<string>
            {
                "Move relative (APT Y)",
                "<!--The table and data cluster are separated here--><Array>",
                "<Name></Name>",
                "<Dimsize>1</Dimsize>",
                "<Cluster>",
                "<Name>Macro Data Cluster</Name>",
                "<NumElts>15</NumElts>",
                "<U32>",
                "test task",
                "test task",
                "test task",
                "test task",
                "cut",
                "cut"
            };
            int expected = 0;

            //Act            
            IList<int> actual = dataProcess.FindTaskSplits(InputListEmpty);

            //Assert
            Assert.AreEqual(actual.Count, expected);
        }

        [TestMethod()]
        public void FindTaskSplitsNoTasksTest()
        {
            //Arrange
            var InputListEmpty = new List<string>
            {

            };
            int expected = 0;

            //Act            
            IList<int> actual = dataProcess.FindTaskSplits(InputListEmpty);

            //Assert
            Assert.AreEqual(actual.Count, expected);
        }
    }
}