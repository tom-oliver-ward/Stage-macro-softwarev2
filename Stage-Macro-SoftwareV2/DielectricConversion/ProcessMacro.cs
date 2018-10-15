using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DielectricConversion
{
    public class ProcessMacro
    {
        //variables to be placed elsewhere

        readonly static string taskSplitString = "<Name>Task Number</Name>";

        public static IList<int> FindTaskSplits(IList<string> rawData)
        {
            var result = Enumerable.Range(0, rawData.Count)
                .Where(i => rawData[i] == taskSplitString)
                .ToList();

            return result;
        }

        //public static IList<string> FindTaskSplits(List<string> rawData)
        //{
        //    List<string> taskSplits = rawData.FindAll(t => t.Equals(taskSplitString));
        //    return taskSplits;
        //}

        //public static IList<int> FindTaskSplits(IList<string> rawData)
        //{
        //    var taskSplits = new List<int>();
        //    for (int i = 0; i < rawData.Count; i++)
        //    {
        //        var pos = rawData[i].IndexOf(taskSplitString);

        //        if (pos > 0)
        //        {
        //            taskSplits.Add(i);
        //            pos = 0;
        //        }
        //    }
        //    return taskSplits;
        //}


        public static IList<string> SplitTasks(IList<string> rawData, IList<int> taskSplits)
        {            
            var rawDataList = new List<string>(rawData);
            var taskList = new List<string>();

            int taskLength = FindTaskLength(taskSplits, rawData.Count);
            for (int i = 0; i < taskSplits.Count; i++)
            {
                var task = (rawDataList.GetRange(taskSplits[i], taskLength - 3));
                var taskString = string.Join("\n", task);
                taskList.Add(taskString);
            }
            return taskList;
        }

        public static int FindTaskLength(IList<int> commandSplits, int totalLength)
        {

            int taskLength;

            //incase there is only one task in the matrix
            try
            {
                taskLength = commandSplits[1] - commandSplits[0];
            }
            catch (System.ArgumentOutOfRangeException)
            {
                taskLength = totalLength - commandSplits[0];
            }
            return taskLength;
        }
    }
}
