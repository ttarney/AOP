using Castle.DynamicProxy;
using Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraceListeners;

namespace Core.Interceptors
{
    //public class MethodCallInterceptor : BaseInterceptor<Log4netTraceListener>
    //{
    //    public MethodCallInterceptor() : base()
    //    {

    //    }
        
    //    public MethodCallInterceptor(Action<IInvocation> invocationAction) : base(invocationAction)
    //    { 
    //    }

    //    public override void Intercept(IInvocation invocation)
    //    {
    //        _traceBridge.WriteMessage(string.Format("Method {0} called.  BEFORE CALL", invocation.Method.Name));
    //        invocation.Proceed();
    //        _traceBridge.WriteMessage(string.Format("Method {0} called.  AFTER CALL", invocation.Method.Name));

    //    }
    //}
}
