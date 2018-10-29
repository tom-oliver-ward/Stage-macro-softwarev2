using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stage_Macro.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage_Macro.Common.Tests
{
    [TestClass()]
    public class BasicOperationsTests
    {
        public static List<string> InputList = new List<string>
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

        public static List<int> TaskSplits = new List<int>
            {
                8,15
            };

        [TestMethod()]
        public void Task2StringTest()
        {
            //arrange
            string expected = "<Name>Task Number</Name>\ntest task\ntest task\ntest task";


            //act
            var actual = BasicOperations.Task2String(InputList, TaskSplits, 8);
                

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void TaskLengthTest()
        {
            var expected = 4;


            //act
            var actual = BasicOperations.TaskLength(TaskSplits, InputList.Count);


            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}