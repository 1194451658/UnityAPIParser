using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CSharpEx
{
    class DebugEx
    {
        public static void LogFormat(string logFormat, params object[] param)
        {
            string log = string.Format(logFormat, param);
            Log(log);
        }

        public static void Log(string log)
        {
            Console.WriteLine(log);
        }

        public static void LogErrorFormat(string logFormat, params object[] param)
        {
            string log = string.Format(logFormat, param);
            LogError(log);
        }

        public static void LogError(string log)
        {
            Console.WriteLine(log);
        }
    }
}
