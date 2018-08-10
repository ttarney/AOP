using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TraceListeners;

namespace Core.Interceptors
{
    public sealed class MethodTimingInterceptor<TListener> : BaseDiagnosticInterceptor<TListener> where TListener : TraceListener
    {
        private string _method = string.Empty;
        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }
        /// <summary>
        /// Allows client to plug in their own handler for the invocation
        /// and testing purposes
        /// </summary>
        public MethodTimingInterceptor(string method) : base()
        {
            _method = method;
            // assure we have removed this
            _invocationDelegate = null;
        }

        public MethodTimingInterceptor(Action<IInvocation> invocationDelegate) : base(invocationDelegate)
        {
        }
    
        // allow for a delegate to be called if needed instead of 
        // hardcoding what this does
        public override void Intercept(IInvocation invocation)
        {
            if (_method != invocation.TargetType.FullName + "." + invocation.Method.Name)
            {
                invocation.Proceed();
                return;
            }
            bool invokeTiming = false;

            Type invocationType = GetInvocationType(invocation);

            if (_invocationDelegate != null)
            {
                _invocationDelegate(invocation);
                invocation.Proceed();
            }
            else
            {
                // replace with action delegate
                Stopwatch watch = new Stopwatch();
                watch.Start();
                invocation.Proceed();
                watch.Stop();

                _traceBridge.WriteMessage(string.Format("Timing was invoked on method: {0}. Took {1}  milliseconds to complete",
                                            invocation.Method.Name, 
                                            watch.ElapsedMilliseconds));
            }
        }
    }
}
