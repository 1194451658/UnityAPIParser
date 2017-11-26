using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

using CSharpEx;

namespace Lang.HtmlTemplate
{
    class HtmlNodeChecker
    {
        private bool _isRequire;       // 此Node是否是必须的
        private string _nodeXPath; 

        public bool IsRequire
        {
            get
            {
                return _isRequire;
            }
        }

        public HtmlNodeChecker(bool isRequire, string nodeXPath)
        {
            _isRequire = isRequire;
            _nodeXPath = nodeXPath;
        }

        public HtmlNode GetNode(HtmlDocument doc)
        {
            if(doc != null)
            {
                return doc.DocumentNode.SelectSingleNode(_nodeXPath);
            }
            else
            {
                DebugEx.LogError("GetNode:doc参数为空！");
            }
            return null;
        }
    }
}
