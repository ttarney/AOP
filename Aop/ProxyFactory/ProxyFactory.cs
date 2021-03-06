﻿using AOPAttributes;
using Castle.DynamicProxy;

using Core.Interceptors;
using ProxyConfiguration;
using ProxyFactory.Strategies.InterceptorCreation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProxyFactory
{

    public interface IProxyFactory<TType> where TType : class, new()
    {
        TType Create();
        TType Create<TListener>();
    }

    //public class ConfigurationProxyFactory<TType> : IProxyFactory<TType> where TType : class, new()
    //{
    //    public ConfigurationProxyFactory()
    //    {

    //    }

    //    public TType Create()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class AttributeProxyFactory<TType> : IProxyFactory<TType> where TType : class, new()
    {
        public AttributeProxyFactory()
        {

        }

        public TType Create<TListener>() 
        {
            return null;
        }
        public TType Create()
        {
            Type invocationType = typeof(TType);
            List<IInterceptor> interceptors = new List<IInterceptor>();
            bool hasClassLevelAttribute = false;
            // if we have a class level attribute
            foreach (var attribute in invocationType.GetCustomAttributes(false))
            {
                // we have to handle all methods
                if (attribute.GetType() == typeof(FeatureClassAttribute))
                {
                    hasClassLevelAttribute = true;
                    MethodInfo[] methodInfos = invocationType.GetMethods();
                    foreach (MethodInfo methodInfo in methodInfos)
                    {
                        FeatureMethodAttribute featureMethodAttribute = new FeatureMethodAttribute((attribute as FeatureClassAttribute).FeatureType);
                        BaseInterceptor interceptor = BaseInterceptorFactory.Create(featureMethodAttribute as Attribute);
                        if (interceptor != null)
                        {
                            interceptors.Add(interceptor);
                        }
                    }
                }
            }
            // if this is defined at the class level we will ignore any other overrides 
            if (!hasClassLevelAttribute)
            {
                // get the custom attributes at the method level
                MethodInfo[] methodInfos = invocationType.GetMethods();
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    // if we have TimeAllMethods add interceptor for every method on the class
                    foreach (var methodAttribute in methodInfo.GetCustomAttributes(false))
                    {
                        BaseInterceptor interceptor = BaseInterceptorFactory.Create(methodAttribute as Attribute);
                        if (interceptor != null)
                        {
                            interceptors.Add(interceptor);
                        }
                    }
                }
            }
            return new ProxyGenerator().CreateClassProxy(typeof(TType),
                                                        interceptors.ToArray()) as TType;
        }
    }
 
    // return that type that will be intercepted
    public static class ProxyFactory<TType> where TType : class, new()
    {
        static ProxyFactory(){ }
       
        public static TType CreateFromConfiguration()
        {
            //ProxyCreationContext<TType> proxyCreationType = new ProxyCreationContext<TType>();
            //return proxyCreationType.Create();
            return null;
        }

        public static TType CreateFromAttributes<TListener>() where TListener : TraceListener
        {
            // strategies should have been created
            Type invocationType = typeof(TType);
            List<IInterceptor> interceptors = new List<IInterceptor>();
            foreach (var attribute in invocationType.GetCustomAttributes(false))
            {

            }

            MethodInfo[] methodInfos = invocationType.GetMethods();
            foreach (MethodInfo methodInfo in methodInfos)
            {
                // if we have TimeAllMethods add interceptor for every method on the class
                foreach (var methodAttribute in methodInfo.GetCustomAttributes(false))
                {

                    dynamic data = methodInfo;
                    BaseDiagnosticInterceptor<TListener> interceptor = BaseDiagnosticInterceptorFactory<TListener>.Create(methodAttribute.GetType().FullName, data);
                    if (interceptor != null)
                    {
                        interceptors.Add(interceptor);
                    }

                }
            }
            return new ProxyGenerator().CreateClassProxy(typeof(TType), interceptors.ToArray()) as TType;
        }
   
        public static TType CreateInternal()
        {
            //ProxyCreationContext<TType> proxyCreationType = new ProxyCreationContext<TType>();
            //return proxyCreationType.Create();
            return null;
        }
    }
}
