using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage_Macro.Common
{
    public static class BasicOperations
    {
        public static string Task2String(List<string> rawData, List<int> taskSplits, int split)
        {

                var task = rawData.
                GetRange(split, TaskLength(taskSplits, rawData.Count));            

            return string.Join("\n", task);
        }

        public static int TaskLength(List<int> commandSplits, int totalLength)
        {
            int taskLength;

            try
            {
                taskLength = commandSplits[1] - commandSplits[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                taskLength = totalLength - commandSplits[0];
            }

            taskLength = taskLength - 3;
            return taskLength;
        }

    }
}
