using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace Lang
{
    class LangObjDef
    {
        private bool _inited = false;

        public virtual string ToDebugStr()
        {
            return null;
        }
    }
}
