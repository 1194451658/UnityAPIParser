using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using CSharpEx;
using HtmlAgilityPack;

using Lang.HtmlTemplate.Unity._2017_3b;

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

            //string htmlFolderPath = @"C:\GameDev\Unity3d\Unity-5.6.0f3\Editor\Data\Documentation\en";
            string htmlFolderPath = @"C:\githud\Project-CSharp\UnityAPIParser\test\html";
            List<string> files = new List<string>();
            DirectoryEx.GetFilesRecursively(htmlFolderPath, ref files);

            DebugEx.LogErrorFormat("文件个数:{0}", files.Count);
            string filesContent = ListEx.ToDebugStr(files);
            //DebugEx.LogErrorFormat("files:\n{0}", filesContent);

            // 先测试解析2个
            for(int i=0; i<files.Count; i++)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(files[i]);

                ClassTemplate classTemp = new ClassTemplate();
                classTemp.initFromHtml(doc);
                
            }

            Console.ReadLine();
        }
    }
}
