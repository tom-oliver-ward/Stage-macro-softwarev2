using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage_Macro.Common
{
    abstract public class DataImported
    {           
        List<string> Tasks { get; set; }        
        
        public abstract List<int> FindTaskSplits(List<string> rawData);
        public abstract List<string> SplitTasks(List<string> rawData, List<int> taskSplits);

        public List<string> Process(List<string> rawData)
        {            
            List<int> TaskSplits = FindTaskSplits(rawData);
            Tasks = SplitTasks(rawData,TaskSplits);
            return Tasks;
        }

    }
}
