using Stage_Macro.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DielectricConversion
{
    public class DataProcess : IDataImported
    {
        public IEnumerable<string> RawData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<string> TaskSplits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<string> Tasks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int taskLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<int> FindTaskSplits(IEnumerable<string> rawData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> SplitTasks(List<string> rawData, List<int> taskSplits)
        {
            throw new NotImplementedException();
        }
    }
}
