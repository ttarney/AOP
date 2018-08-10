using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyLib
{
    public abstract class ProxyBase
    {
        protected ProxyGenerator _generator = new ProxyGenerator();

        public abstract TType CreateClassProxy<TType>(params object[] arguments) where TType : class, new();
    }
}
