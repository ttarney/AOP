using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimingInterceptor
{
    public sealed class MethodTimingInterceptor : IInterceptor
    {

        public void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
