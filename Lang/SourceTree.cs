using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang
{
    // 代表一个代码工程
    class SourceTree
    {
        private Dictionary<string, ClassDef> allClassDic = new Dictionary<string, ClassDef>();



        public ClassDef GetClassDef(string nsName, string className)
        {
            string classFullName = string.Format("{0}.{1}", nsName, className);
            return GetClassDef(classFullName);
        }

        public ClassDef GetClassDef(string classFullName)
        {
            if (allClassDic.ContainsKey(classFullName))
                return allClassDic[classFullName];
            return null;
        }

        public ClassDef CreateClassDef(string nsName, string className)
        {




            return null;
        }
    }
}
