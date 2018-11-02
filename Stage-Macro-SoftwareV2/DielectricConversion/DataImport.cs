using System;
using Stage_Macro.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DielectricConversion 
{
    public class DataImport
    {
        static List<string> data;
        static DataFormat dataFormat = new DataFormat(data);

        public static void Execute()
        {
            //Open file from common and import data 
                dataFormat.Process(data);            
            //Read Macro
            //Display Macro
        }
    }
}
