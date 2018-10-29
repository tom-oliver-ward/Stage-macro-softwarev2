using Stage_Macro.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DielectricConversion
{
    public class DataProcess : DataImported
    {                
        IEnumerable<string> Tasks { get; set; }
        readonly static string taskSplitString = "<Name>Task Number</Name>";
        List<string> rawDataList { get; set; }

        public DataProcess(IEnumerable<string> rawData)
        {
            rawDataList = rawData.ToList();
        }

        public override List<string> SplitTasks(List<string> rawData, List<int> taskSplits)
        {
            var taskList = new List<string>();

            for(int split=0; split < taskSplits.Count-1; split++)
            {
                string taskString = BasicOperations.Task2String(rawData, taskSplits, taskSplits[split]);
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
