using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.AopInterceptors
{
    public sealed class MethodTimingInterceptor : IInterceptor
    {
        public MethodTimingInterceptor()
        {

        }

        public void Intercept(IInvocation invocation)
        {
            bool invokeTiming = false;

            Type invocationType = Type.GetType(invocation.TargetType.FullName);
            foreach(CustomAttributeData customAttribute in invocationType.GetMethod(invocation.Method.Name).CustomAttributes)
            {
                if(customAttribute.AttributeType == typeof(Core.Attributes.MethodTimingAttribute))
                {
                    invokeTiming = true;
                    break;
                }
            }
            if (invokeTiming)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                invocation.Proceed();
                watch.Stop();

                Console.WriteLine("Timing was invoked on method: " +
                                            invocation.Method.Name +
                                            ". Took " +
                                            watch.ElapsedMilliseconds +
                                            " milliseconds to complete");
            }


        }
    }
}
