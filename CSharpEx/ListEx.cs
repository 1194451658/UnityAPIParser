using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEx
{
    class ListEx
    {
        public static string ToDebugStr(List<string> strList)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<strList.Count; i++)
                sb.AppendLine(strList[i]);
            return sb.ToString();
        }
    }
}
