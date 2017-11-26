using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CSharpEx
{
    class DirectoryEx
    {
        // 遍历得到所有文件
        public static void GetFilesRecursively(string folderPath, Action<string> fileCallback)
        {
            if (Directory.Exists(folderPath))
            {
                string[] fileArr = Directory.GetFiles(folderPath);
                for (int i = 0; i < fileArr.Length; i++)
                    fileCallback(fileArr[i]);
                string[] subDirArr = Directory.GetDirectories(folderPath);
                for (int i = 0; i < subDirArr.Length; i++)
                    GetFilesRecursively(subDirArr[i], fileCallback);
            }
            else
            {
                DebugEx.LogErrorFormat("GetFilesRecursively：没有找到目录{0}", folderPath);
            }
        }

        public static void GetFilesRecursively(string folderPath, ref List<string> fileList)
        {
            if(fileList != null)
            {
                List<string> files = new List<string>();
                GetFilesRecursively(folderPath, (string filePath) =>
                {
                    files.Add(filePath);
                });
                fileList.AddRange(files);
            }
        }
    }
}
