using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using CSharpEx;

namespace UnityAPIParser
{
    public class TestClass
    {


    }

    class Program
    {
        static void Main(string[] args)
        {

            // 遍历目录

            string htmlFolderPath = @"C:\GameDev\Unity3d\Unity-5.6.0f3\Editor\Data\Documentation\en";
            List<string> files = new List<string>();
            DirectoryEx.GetFilesRecursively(htmlFolderPath, ref files);

            DebugEx.LogErrorFormat("文件个数:{0}", files.Count);
            string filesContent = ListEx.ToDebugStr(files);
            //DebugEx.LogErrorFormat("files:\n{0}", filesContent);

            Console.ReadLine();
        }
    }
}
