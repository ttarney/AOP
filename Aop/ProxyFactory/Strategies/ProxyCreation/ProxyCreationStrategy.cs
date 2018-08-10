using Castle.DynamicProxy;
using Core.Interceptors;
using ProxyFactory.Strategies.InterceptorCreation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TraceListeners;

namespace ProxyFactory
{
    public interface IProxyCreationStrategy<TType>
    {
        TType Create();
        TType CreateFromAttributes<TListener>() where TListener : TraceListener;
    }
}


    // creates a proxy object of classes 
//    public class ClassProxyCreationStrategy<TType> : IProxyCreationStrategy<TType>
//                                                            where TType : class, new()
//    {

//        // create the actual type of object and attach the 
//        // interceptors so that they can be executed upon
//        public TType Create()
//        {
//            // this method gets the interceptors that are configured through 
//            // configuration files

//            IInterceptor[] interceptors = ProxyConfigHelper.GetConfiguredInterceptors(typeof(TType));
//            return new ProxyGenerator().CreateClassProxy(typeof(TType), interceptors) as TType;
//        }

//    //    public TType CreateFromAttributes<TListener>() where TListener : TraceListener
//    //    {
//    //        // this method gets the interceptors that are configured through 
//    //        // Custom Attributes

//    //        Type invocationType = typeof(TType);
//    //        List<IInterceptor> interceptors = new List<IInterceptor>();
//    //        foreach (var attribute in invocationType.GetCustomAttributes(false))
//    //        {
                
//    //        }

//    //        MethodInfo[] methodInfos = invocationType.GetMethods();
//    //        foreach(MethodInfo methodInfo in methodInfos)
//    //        {
//    //            // if we have TimeAllMethods add interceptor for every method on the class
//    //            foreach (var methodAttribute in methodInfo.GetCustomAttributes(false))
//    //            {
                    
//    //                dynamic data = methodInfo;
//    //                BaseDiagnosticInterceptor<TListener> interceptor = BaseDiagnosticInterceptorFactory<TListener>.Create(methodAttribute.GetType().FullName, data);
//    //                if (interceptor != null)
//    //                {
//    //                    interceptors.Add(interceptor);
//    //                }
                   
//    //            }
//    //        }
//    //        return new ProxyGenerator().CreateClassProxy(typeof(TType), interceptors.ToArray()) as TType;
//    //    }
//    //}

//    //public class InterfaceProxyCreationStrategy<TType> : IProxyCreationStrategy<TType>
//    //{

//    //    public TType Create()
//    //    {
//    //        throw new NotImplementedException();
//    //    }

//    //    public TType CreateFromAttributes()
//    //    {
//    //        throw new NotImplementedException();
//    //    }

//    //}

//    public class ProxyCreationContext<TType> where TType : class, new()
//    {
//        private Dictionary<string, IProxyCreationStrategy<TType>> _strategies = new Dictionary<string, IProxyCreationStrategy<TType>>();


//        // load up the interceptors that we are configured for 
//        // probably could cache these
//        public ProxyCreationContext()
//        {
//            _strategies.Add("Class", new ClassProxyCreationStrategy<TType>());
//           // _strategies.Add("Interface", new InterfaceProxyCreationStrategy<TType>());
//        }

//        public TType Create()
//        {
//            // get items from configuration file
//            string proxyCreationType = ProxyConfigHelper.GetProxyType(typeof(TType));
//            return _strategies[proxyCreationType].Create();
//        }
//        public TType CreateTemp()
//        {     
//            //// get items from configuration file
//            string proxyCreationType = "Class";// ProxyConfigHelper.GetProxyType(typeof(TType));

//            // get the attribt
//            //return _strategies[proxyCreationType].CreateFromAttributes();//CreateFromAttributes();
//            return null;
//        }

//        public TType CreateFromAttributes<TListener>() where TListener : TraceListener
//        {
//            //// get items from configuration file
//            string proxyCreationType = "Class";// ProxyConfigHelper.GetProxyType(typeof(TType));

//            // get the attribt
//            return _strategies[proxyCreationType].CreateFromAttributes<TListener>();//CreateFromAttributes();
//        }
//    }
//}
