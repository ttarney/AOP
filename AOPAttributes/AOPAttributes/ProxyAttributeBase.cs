using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPAttributes
{
    public class ProxyAttributeBase : Attribute
    {
        public bool Active { get; set; }
    }
}
