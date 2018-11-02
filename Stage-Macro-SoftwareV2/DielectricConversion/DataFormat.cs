using Stage_Macro.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DielectricConversion
{
    public class DataFormat : Stage_Macro.Common.DataFormat
    {                
        IEnumerable<string> Tasks { get; set; }
        readonly static string taskSplitString = "<Name>Task Number</Name>";
        List<string> rawDataList { get; set; }

        public DataFormat(IEnumerable<string> rawData)
        {
            rawDataList = rawData.ToList();
        }

        public override List<string> SplitTasks(List<string> rawData, List<int> taskSplits)
        {
            var taskList = new List<string>();
            var tasklength = BasicOperations.TaskLength(taskSplits, rawData.Count);

            for (int split = 0; split < taskSplits.Count; split++) 
            {
                string taskString = BasicOperations.Task2String(rawData, tasklength, taskSplits[split]);
                taskList.Add(taskString);
            }
            return taskList;
        }

        public override List<int> FindTaskSplits(List<string> rawData)
        {
            var result = Enumerable.Range(0, rawData.Count)
                .Where(i => rawData[i] == taskSplitString)
                .ToList();
            return result;
        }
    }
}
