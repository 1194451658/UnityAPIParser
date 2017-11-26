using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang
{
    class ClassDef: LangObjDef
    {
        public string name;
        public ClassDef parent;
        public NamespaceDef ns;
        public string shortDes;

        public List<PropertyDef> properties;
        public List<FuncDef> funcs;
        public List<EventDef> events;
        public List<DelegateDef> delegates;
        public List<OperatorDef> operators;
    }
}
