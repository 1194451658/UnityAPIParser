using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

using CSharpEx;

namespace Lang.HtmlTemplate
{
    class HtmlTemplate
    {
        private Dictionary<string, HtmlNodeChecker> nodeCheckerDic = new Dictionary<string, HtmlNodeChecker>();
        private HtmlDocument _doc;
        private bool _docValid = false;

        public HtmlTemplate(string html)
        {
            _doc = new HtmlDocument();
            _doc.Load(html);
        }

        public HtmlTemplate(HtmlDocument htmlDoc)
        {
            _doc = htmlDoc;
        }

        // 检查此Html格式，是否所有必须的Node都存在
        protected bool IsAllNodeValid()
        {
            foreach(KeyValuePair<string, HtmlNodeChecker> nodeNameAndChecker in nodeCheckerDic)
            {
                HtmlNodeChecker checker = nodeNameAndChecker.Value;
                if (checker.IsRequire)
                {
                    if (checker.GetNode(_doc) == null)
                        return false;
                }
            }

            return true;
        }

        // 添加检查Node的规则
        public void AddNodeChecker(string name, bool isRequire, string xPath)
        {
            HtmlNodeChecker checker = new HtmlNodeChecker(isRequire, xPath);
            AddNodeChecker(name, checker);
        }

        // 添加检查Node的规则
        public void AddNodeChecker(string name, HtmlNodeChecker checker)
        {
            if(!nodeCheckerDic.ContainsKey(name))
            {
                nodeCheckerDic.Add(name, checker);
            }
            else
            {
                DebugEx.LogErrorFormat("AddNodeChecker：重复的checker name:{0}", name);
            }
        }

        // 根据指定的Node规则，获取Node
        public HtmlNode GetNode(string nodeCheckerName)
        {
            if (nodeCheckerDic.ContainsKey(nodeCheckerName))
            {
                HtmlNodeChecker checker = nodeCheckerDic[nodeCheckerName];
                return checker.GetNode(_doc);
            }
            else
            {
                DebugEx.LogErrorFormat("GetNode:没有找到node checker ：{0}", nodeCheckerName);
            }

            return null;
        }
    }
}
