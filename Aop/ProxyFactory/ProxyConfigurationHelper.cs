using Castle.DynamicProxy;
using Core.Interceptors;
using ProxyConfiguration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyFactory
{
    public static class ProxyConfigHelper
    {
        public static string GetProxyType(Type typeToIntercept)
        {
            TypeElement typeElement = GetTypeElement(typeToIntercept.Name);
            return typeElement.ProxyType;
        }


        // returns the interceptors that are currently configured for a specified type
        // this can be configuration or attribute based
        public static IInterceptor[] GetConfiguredInterceptors(Type typeToIntercept)
        {
            List<IInterceptor> interceptors = new List<IInterceptor>();

            // check first to see if the type implements one of the 
            // attributes

            //TypeElement typeElement = GetTypeElement(typeToIntercept.Name);
            //{
            //    foreach (InterceptorElement interceptor in typeElement.Interceptors.AsEnumerable())
            //    {
            //        if (interceptor.Active == true)
            //        {
            //            switch (interceptor.Name)
            //            {
            //                case "MethodDetail":
            //                case "MethodDetailsInterceptor":
            //                case "AopInterceptors.Interceptors.MethodDetailInterceptor":
            //                    MethodDetailsInterceptor methodDetailsInterceptor = new MethodDetailsInterceptor();
            //                    foreach(MethodElement methodElement in interceptor.Methods)
            //                    {
            //                        if(methodElement.Active == true)
            //                        {
            //                            methodDetailsInterceptor.AddMethodDetails(new MethodDetails
            //                            {
            //                                Active = methodElement.Active,
            //                                Name = methodElement.Name,
            //                                Property = methodElement.Property, 
            //                                Stage = methodElement.Stage,
            //                                FileName = methodElement.FileName,
            //                                ProxyMethod = methodElement.ProxyMethod,
            //                                RawContent = methodElement.RawContent,
            //                                ProxyParameter = methodElement.ProxyParameter
                                            
            //                            });
            //                        }
            //                    }
            //                    interceptors.Add(methodDetailsInterceptor);
            //                    break;
            //                case "MethodTimingInterceptor":
            //                    interceptors.Add(new MethodTimingInterceptor());
            //                    break;
            //                case "MethodCallInterceptor":
            //                    interceptors.Add(new MethodCallInterceptor());
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //    }
            //}
            return interceptors.ToArray();
        }

        private static TypeElement GetTypeElement(string typeToIntercept)
        {
            try
            {
                ProxyConfigSection configSettings = (ProxyConfigSection)ConfigurationManager.GetSection("proxyConfiguration");
                return configSettings.ConfigElements.Where(t => t.Name == typeToIntercept).FirstOrDefault();
            }
            catch(Exception ex)
            {
                int x = 0;
            }
            return null;
           
        }
    }
}
