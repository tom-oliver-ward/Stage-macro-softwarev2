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

        public DataProcess()
        {

        }

        public override IEnumerable<int> FindTaskSplits(IEnumerable<string> rawData)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> SplitTasks(List<string> rawData, List<int> taskSplits)
        {
            throw new NotImplementedException();
        }
    }
}
