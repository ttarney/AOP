using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraceListeners;

namespace Core.Interceptors
{

    public abstract class BaseInterceptor : IInterceptor
    {
        protected Action<IInvocation> _invocationDelegate;
       
        protected BaseInterceptor()
        {
            _invocationDelegate = null;
        }
        protected BaseInterceptor(Action<IInvocation> invocationDelegate)
        {
            _invocationDelegate = invocationDelegate;
        }

        protected Type GetInvocationType(IInvocation invocation)
        {
            Type invocationType = Type.GetType(invocation.TargetType.FullName);
            if (invocationType == null)
            {
                // try to load it from the assembly because we don't have it
                // IE in a unit test scenario
                invocationType = invocation.TargetType.Assembly.GetType(invocation.TargetType.FullName);
            }
            return invocationType;
        }

        public abstract void Intercept(IInvocation invocation);

    }
    /// <summary>
    /// Provides the base interceptor and implements TListener to output detail to
    /// </summary>
    /// <typeparam name="TListener"></typeparam>
    public abstract class BaseDiagnosticInterceptor<TListener> : IInterceptor
                                        where TListener : TraceListener
    {
        protected Action<IInvocation> _invocationDelegate;
        protected TraceBridge<TListener> _traceBridge = new TraceBridge<TListener>();

        protected BaseDiagnosticInterceptor()
        {
            _invocationDelegate = null;
        }
        protected BaseDiagnosticInterceptor(Action<IInvocation> invocationDelegate)
        {
            _invocationDelegate = invocationDelegate;
        }

        protected Type GetInvocationType(IInvocation invocation)
        {
            Type invocationType = Type.GetType(invocation.TargetType.FullName);
            if (invocationType == null)
            {
                // try to load it from the assembly because we don't have it
                // IE in a unit test scenario
                invocationType = invocation.TargetType.Assembly.GetType(invocation.TargetType.FullName);
            }
            return invocationType;
        }

        public abstract void Intercept(IInvocation invocation);
    }
}
