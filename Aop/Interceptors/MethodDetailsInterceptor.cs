using Castle.DynamicProxy;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TraceListeners;

namespace Core.Interceptors
{
    public class MethodDetails
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Property { get; set; }
        public string Stage { get; set; }
        public string FileName { get; set; }
        public string ProxyMethod { get; set; }
        public bool RawContent { get; set; }
        public string ProxyParameter { get; set; }
    }
    public class MethodDetailsInterceptor<TListener> : BaseDiagnosticInterceptor<TListener> where TListener : TraceListener
    {
        private List<MethodDetails> _methodDetailsToIntercept = new List<MethodDetails>();
        public MethodDetailsInterceptor(MethodDetails methodDetails) : base()
        {
            _methodDetailsToIntercept.Add(methodDetails);
        }

        public void AddMethodDetails(MethodDetails methodDetails)
        {
            _methodDetailsToIntercept.Add(methodDetails);
        }

        public MethodDetailsInterceptor(Action<IInvocation> invocationDelegate)
            : base(invocationDelegate)
        {

        }

        public override void Intercept(IInvocation invocation)
        {
            _traceBridge.WriteInformation(string.Format("Intercepted call to: {0} with parameters:", invocation.Method.Name));
            PropertyInfo propertyInfo = null;

            MethodDetails methodDetails = _methodDetailsToIntercept.Where(methodDetail => methodDetail.Name == invocation.Method.Name).FirstOrDefault();
            Type invocationType = GetInvocationType(invocation);

            if (methodDetails != null)
            {
                propertyInfo = invocationType.GetProperty(methodDetails.Property);
                if (methodDetails.Stage == "before" || methodDetails.Stage == "both")
                {
                    object o = propertyInfo.GetValue(invocation.Proxy, null);
                    string message = string.Empty;
                    if (!string.IsNullOrEmpty(methodDetails.ProxyMethod))
                    {
                        MethodInfo methodInfo = invocationType.GetMethod(methodDetails.ProxyMethod);

                        ParameterInfo parameters = invocation.Method.GetParameters().Where(p => p.Name == "ruleFlowId").FirstOrDefault();

                        object test = methodInfo.Invoke(invocation.Proxy, null);
                        message = test.ToString();
                    }
                    else
                    {
                        if (methodDetails.RawContent)
                        {
                            message = o.ToString();
                        }
                        else
                        {
                            message = string.Format("Invocation on Method {0}.  Property Value {1} BEFORE invocation: {2}",
                                                            invocation.Method.Name, methodDetails.Property, o.ToString());
                        }
                    }
                    if (!string.IsNullOrEmpty(methodDetails.FileName))
                    {
                        OutputToFile(methodDetails.FileName, message);
                    }
                    else
                    {
                        _traceBridge.WriteMessage(message);
                    }

                }

            }

            invocation.Proceed();
            if (propertyInfo != null)
            {
                if (methodDetails.Stage == "after" || methodDetails.Stage == "both")
                {
                    object o = propertyInfo.GetValue(invocation.Proxy, null);

                    string message = string.Empty;
                    message = string.Format("Invocation on Method {0}.  Property Value {1} AFTER invocation: {2}",
                                 invocation.Method.Name, methodDetails.Property, o.ToString());

                    _traceBridge.WriteMessage(message);


                    //if (!string.IsNullOrEmpty(methodDetails.ProxyMethod))
                    //{
                    //    if (!string.IsNullOrEmpty(methodDetails.ProxyParameter))
                    //    {
                    //        ParameterInfo parameter = invocation.Method.GetParameters().Where(p => p.Name == "ruleFlowId").FirstOrDefault();
                    //        object val = invocation.Arguments[parameter.Position];


                    //        object[] inputs = new object[] { val };
                    //        object test = methodInfo.Invoke(invocation.Proxy, inputs);
                    //        message = test.ToString();
                    //    }
                    //    else
                    //    {
                    //        object test = methodInfo.Invoke(invocation.Proxy, null);
                    //        message = test.ToString();

                    //    }

                    //}
                    //else
                    //{
                    //    if (methodDetails.RawContent)
                    //    {
                    //        message = o.ToString();
                    //    }
                    //    else
                    //    {
                    //        message = string.Format("Invocation on Method {0}.  Property Value {1} AFTER invocation: {2}",
                    //                                      invocation.Method.Name, methodDetails.Property, o.ToString());
                    //    }
                    //}
                    //if (!string.IsNullOrEmpty(methodDetails.FileName))
                    //{
                    //    OutputToFile(methodDetails.FileName, message);
                    //}
                    //else
                    //{
                    _traceBridge.WriteMessage(message);
                    //}
                }
            }
        }

        private void LogTiming(IInvocation invocation)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            invocation.Proceed();
            watch.Stop();
            _traceBridge.WriteInformation(string.Format("Timing invoked on method {0}.  Elapsed Milliseconds: {1}",
                                            invocation.Method.Name,
                                            watch.ElapsedMilliseconds));
        }

        private void OutputToFile(string fileName, string message)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(message);
                writer.Flush();
            }
        }
    }
}
