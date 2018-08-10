using AOPInterceptors;
using Castle.DynamicProxy;
using Core.Attributes;
using Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TraceListeners;

namespace ProxyFactory.Strategies.InterceptorCreation
{
    public interface IInterceptorCreation
    {
        IInterceptor Create();
        IInterceptor Create(string id);
    }

    

    public static class BaseInterceptorFactory
    {
        public static BaseInterceptor Create(Attribute attribute)
        {
            BaseInterceptor baseInterceptor = null;
            if (attribute.GetType() == typeof(Core.Attributes.FeatureMethodAttribute))
            {
                baseInterceptor = FeatureMethodInterceptorFactory.Create<FeatureMethodAttribute>((attribute as FeatureMethodAttribute));
            }
            return baseInterceptor;
        }
    }


    public static class BaseDiagnosticInterceptorFactory<TListener> where TListener : TraceListener
    {
        public static BaseDiagnosticInterceptor<TListener> Create(string type, dynamic data) 
        {
            // add strategies here
            BaseDiagnosticInterceptor<TListener> baseInterceptor = null;
            if(type == "Core.Attributes.MethodTimingAttribute")
            {
                baseInterceptor = MethodTimingInterceptorFactory<TListener>.Create(data);
            }

            else if (type == "Core.Attributes.MethodDetailLoggingAttribute")
            {
                baseInterceptor = MethodDetailsInterceptorFactory<TListener>.Create(data);
            }
            return baseInterceptor;
        }
    }

    public static class MethodDetailsInterceptorFactory<TListener> where TListener : TraceListener
    {
        public static IInterceptor Create(dynamic data)
        {
            MethodInfo methodInfo = (MethodInfo)data;
            var attribute = methodInfo.GetCustomAttributes(typeof(MethodDetailLoggingAttribute), false);
            //string method = methodInfo.ReflectedType.FullName + "." + methodInfo.Name;

            MethodDetails methodDetails = new MethodDetails()
            {
                Property = "X",
                Stage = "both",
                Name = "Baz"
            };
            return new MethodDetailsInterceptor<TListener>(methodDetails);
        }
        //public IInterceptor Create()
        //{
        //    return new MethodDetailsInterceptor();
        //}
    }

    public static class FeatureMethodInterceptorFactory
    {
        public static BaseInterceptor Create<T>(Attribute attribute)
        {
            FeatureMethodAttribute featureMethodAttribute = (FeatureMethodAttribute)attribute;
            
            return new FeatureMethodInterceptor(featureMethodAttribute.FeatureType);
        }
    }
    public static class MethodTimingInterceptorFactory<TListener> where TListener : TraceListener
    {
        public static BaseDiagnosticInterceptor<TListener> Create(dynamic data)
        { 
            MethodInfo methodInfo = (MethodInfo)data;
            string method = methodInfo.ReflectedType.FullName + "." + methodInfo.Name;
            return new MethodTimingInterceptor<TListener>(method);
        }

        //public static BaseInterceptor<Log4netTraceListener> Create(string method)
        //{
        //    return new MethodTimingInterceptor<Log4netTraceListener>(method);
        //}
    }

    //public class MethodCallInterceptorFactory : IInterceptorCreation
    //{
    //    public IInterceptor Create(string id)
    //    {
    //        return new MethodCallInterceptor();
    //    }

    //    public IInterceptor Create()
    //    {
    //        return new MethodCallInterceptor();
    //    }
    //}


    public class InterceptorCreationContext : IInterceptorCreation
    {
          //{
          //                  case "MethodDetail":
          //                  case "MethodDetailsInterceptor":
          //                  case "AopInterceptors.Interceptors.MethodDetailInterceptor":
          //                      interceptors.Add(new MethodDetailsInterceptor());
          //                      break;
          //                  case "MethodTimingInterceptor":
          //                      interceptors.Add(new MethodTimingInterceptor());
          //                      break;
          //                  case "MethodCallInterceptor":
          //                      interceptors.Add(new MethodCallInterceptor());
          //                      break;
          //                  default:
          //                      break;
          //              }
        //private Dictionary<string, IProxyCreation<TType>> _strategies = new Dictionary<string, IInterceptorFactory>();

        public InterceptorCreationContext()
        {
            //_strategies.Add("MethodDetailsInspector", new ClassProxyCreationStrategy<TType>());
            //_strategies.Add("Interface", new InterfaceProxyCreationStrategy<TType>());
        }

        public IInterceptor Create(string id)
        {
            throw new NotImplementedException();
        }

        public IInterceptor Create()
        {
            throw new NotImplementedException();
        }
    }
}
