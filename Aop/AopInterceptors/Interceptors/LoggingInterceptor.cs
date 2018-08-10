using Castle.DynamicProxy;
using Core.Attributes;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TraceListeners;

namespace AopInterceptors.Interceptors
{
   // public class MethodDetailsInterceptor : IInterceptor 
   // {
        //private TraceBridge<Log4netTraceListener> _traceBridge = new TraceBridge<Log4netTraceListener>();
        
        //public void Intercept(IInvocation invocation)
        //{
        //    Type invocationType = Type.GetType(invocation.TargetType.FullName);
        //    if(invocationType == null)
        //    {
        //        // try to load it from the assembly because we don't have it
        //        // IE in a unit test scenario
        //        invocationType = invocation.TargetType.Assembly.GetType(invocation.TargetType.FullName);
        //    }
            
        //    MethodInfo methodInfo = invocationType.GetMethod(invocation.Method.Name);
        //    MethodDetailLoggingAttribute methodLoggingAttribute = System.Attribute.GetCustomAttributes(methodInfo).Where(t => t.GetType() == typeof(MethodDetailLoggingAttribute)).FirstOrDefault() as MethodDetailLoggingAttribute;
        //    if (methodLoggingAttribute != null && methodLoggingAttribute.LogDetail)
        //    {

        //        _traceBridge.WriteInformation(string.Format("Intercepted call to: {0} with parameters:", invocation.Method.Name));

        //        foreach (object argument in invocation.Arguments)
        //        {
        //            _traceBridge.WriteMessage(string.Format("   Type: {0}  Value: {1}", 
        //                                                argument.GetType().ToString(), 
        //                                                argument));
        //        }
        //    }
        //    if (methodLoggingAttribute.LogDetail)
        //    {
        //        LogTiming(invocation);
        //    }
        //    else
        //    {
        //        invocation.Proceed();
        //    }
        //}

        //private void LogTiming(IInvocation invocation)
        //{
        //    Stopwatch watch = new Stopwatch();
        //    watch.Start();
        //    invocation.Proceed();
        //    watch.Stop();
        //    _traceBridge.WriteInformation(string.Format("Timing invoked on method {0}.  Elapsed Milliseconds: {1}",
        //                                    invocation.Method.Name,
        //                                    watch.ElapsedMilliseconds));
        //}
   // }
}
