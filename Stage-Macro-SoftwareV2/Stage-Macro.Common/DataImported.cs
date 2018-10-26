using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage_Macro.Common
{
    abstract public class DataImported
    {
        IEnumerable<string> RawData { get; set; }
        IEnumerable<string> TaskSplits { get; set; }
        IEnumerable<string> Tasks { get; set; }
        int taskLength { get; set; }
        string taskSplitString { get;}

        public abstract IEnumerable<int> FindTaskSplits(IEnumerable<string> rawData);
        public abstract IEnumerable<string> SplitTasks(List<string> rawData, List<int> taskSplits);

    }
}
