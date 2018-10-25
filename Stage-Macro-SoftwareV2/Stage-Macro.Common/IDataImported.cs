using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage_Macro.Common
{
    public interface IDataImported
    {
        IEnumerable<string> RawData { get; set; }
        IEnumerable<string> TaskSplits { get; set; }
        IEnumerable<string> Tasks { get; set; }
        int taskLength { get; set; }

        IEnumerable<int> FindTaskSplits(IEnumerable<string> rawData);
        IEnumerable<string> SplitTasks(List<string> rawData, List<int> taskSplits)

    }
}
