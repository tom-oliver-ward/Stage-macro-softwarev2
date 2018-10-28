using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stage_Macro.Common;

namespace DielectricConversion
{
    public class ProcessMacro    {

        readonly static string taskSplitString = "<Name>Task Number</Name>";
        public static IEnumerable<string> ConvertMacro (IEnumerable<string> rawData)
        {
            
            List<string> rawDataList = rawData.ToList();
            return SplitTasks(rawDataList, FindTaskSplits(rawDataList));
        }

        public static List<int> FindTaskSplits(IEnumerable<string> rawData)
        {
            List<string> rawDataList = rawData.ToList();

            var result = Enumerable.Range(0, rawDataList.Count)
                .Where(i => rawDataList[i] == taskSplitString)
                .ToList();

            return result;
        }

        public static List<string> SplitTasks(List<string> rawData, List<int> taskSplits)
        {            
            var taskList = new List<string>();

            foreach(int split in taskSplits)
            {
                string taskString = BasicOperations.Task2String(rawData, taskSplits, split);                
                taskList.Add(taskString);
            }
            return taskList;
        }        
    }
}
