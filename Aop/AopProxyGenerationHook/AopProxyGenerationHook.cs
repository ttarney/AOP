using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ProxyGenerationHook
{
    public class AopProxyGenerationHook : IProxyGenerationHook
    {

        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, System.Reflection.MemberInfo memberInfo)
        {

        }

        // will make sure that we only call if it's a get request
        public bool ShouldInterceptMethod(Type type, System.Reflection.MethodInfo methodInfo)
        {
            return !methodInfo.Name.StartsWith("get_", StringComparison.OrdinalIgnoreCase);
        }
    }
}
