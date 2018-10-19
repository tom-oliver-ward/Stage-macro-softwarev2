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
        readonly static int taskLength = 190;
        readonly static string taskSplitString = "<Name>Task Number</Name>";

        public static IList<int> FindTaskSplits(IList<string> rawData)
        {
            var result = Enumerable.Range(0, rawData.Count)
                .Where(i => rawData[i] == taskSplitString)
                .ToList();

            return result;
        }


        public static List<string> SplitTasks(List<string> rawData, List<int> taskSplits)
        {

            var taskList = Enumerable.Range(0, taskSplits.Count)
                .Select(index => rawData.GetRange(taskSplits[index], taskLength))
                .ToList();

            //return taskList;
            var Empty = new List<string>();
            return Empty;
        }

        //public static IList<string> SplitTasks(IList<string> rawData, IList<int> taskSplits)
        //{            
        //    var rawDataList = new List<string>(rawData);
        //    var taskList = new List<string>();

        //    int taskLength = FindTaskLength(taskSplits, rawData.Count);
        //    for (int i = 0; i < taskSplits.Count; i++)
        //    {
        //        var task = (rawDataList.GetRange(taskSplits[i], taskLength - 3));
        //        var taskString = string.Join("\n", task);
        //        taskList.Add(taskString);
        //    }
        //    return taskList;
        //}

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
