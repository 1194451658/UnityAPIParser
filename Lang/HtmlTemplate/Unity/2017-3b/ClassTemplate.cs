using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;
using CSharpEx;

namespace Lang.HtmlTemplate.Unity._2017_3b
{
    class ClassTemplate: HtmlTemplate
    {
        private string nameXPath = "//h1[@class='heading inherit']";
        private string nsNameXPath = "//p[@class='cl mb0 left mr10']";
        private string classParentXPath = "//p[string()='Inherits from:']/a";
        private string shortDescXPath = "//h2[string()='Description']/following-sibling[1]";

        private string propertiesXPath = "//h2[string()='Properties']/../table/tbody";
        private string publicMethodsXPath = "//h2[string()='Public Methods']/../table/tbody";

        private string staticPropertiesXPath = "//h2[string()='Static Properties']/../table/tbody";
        private string staticMethodsXPath = "//h2[string()='Static Methods']/../table/tbody";

        private string eventXPath = "//h2[string()='Events']/../table/tbody";
        private string delegateXPath = "//h2[string()='Delegates']/../table/tbody";


        public ClassTemplate(string html) : base(html)
        {
            AddNodeChecker("name", true, nameXPath);
            AddNodeChecker("nsName", true, nsNameXPath);
            AddNodeChecker("classParent", false, classParentXPath);
            AddNodeChecker("shortDesc", true, shortDescXPath);

            AddNodeChecker("properties", false, propertiesXPath);
            AddNodeChecker("publicMethod", false, publicMethodsXPath);

            AddNodeChecker("staticProperties", false, staticPropertiesXPath);
            AddNodeChecker("staticPublicMethods", false, staticMethodsXPath);

            AddNodeChecker("event", false, eventXPath);
            AddNodeChecker("delegate", false, delegateXPath);
        }

        // 得到定义的数据
        // 注意：没有进行Html格式正确行检验，需要自己调用IsAllNodeValid()函数
        public ClassDef GetClassDef(SourceTree sourceTree)
        {
            //ClassDef newDef = new ClassDef();

            string className = "";
            string classNsFullName = "";

            HtmlNode nameNode = GetNode("name");
            if (nameNode != null)
                className = nameNode.InnerText;

            HtmlNode nsNameNode = GetNode("nsName");
            if (nsNameNode != null)
            {
                if (nsNameNode.InnerText.StartsWith("class in"))
                    classNsFullName = nsNameNode.InnerText.Substring("class in".Length);
            }

            // 检查是否有重复定义
            if(sourceTree.GetClassDef(classNsFullName, className) == null)
            {
                ClassDef newDef = sourceTree.CreateClassDef(classNsFullName, className);



            }
            else
            {
                DebugEx.LogErrorFormat("错误，GetClassDef拥有重复的classDef ns:{0} clsName:{1}", classNsFullName, classNsFullName);
            }

            return null;
        }
    }
}
