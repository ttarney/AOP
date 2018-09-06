using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;

using Core.Interceptors;
using ProxyConfiguration;

using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using TraceListeners;
using AopProxyUnitTest.FeatureFlags;
using ProxyFactory;
using AOPAttributes;
using AOPDemoClasses;

namespace AopProxyUnitTest
{
   
    //[TimeAllMethods(LogTiming = true)]



    public class AopProxyUnitTest
    {
        [TestClass]
        public class CreateProxyTest
        {
            [TestMethod]
            public void Test_Create_Object_Successful()
            {
                //Foo foo = ProxyFactory.ProxyFactory<Foo>.Create();
                //foo.Bar(3);
                //foo.Baz(5888, "hello there", 45.44);
                //foo.FooBaz(5888, "hello there", 45.44, new Temp("ouch"));
            }

            [TestMethod]
            public void Test_Create_Object_Attribute_Successful()
            {
                Foo foo1 = ProxyFactory.ProxyFactory<Foo>.CreateFromAttributes<Log4netTraceListener>();
                //Foo foo = ProxyFactory.ProxyFactory<Foo>.CreateFromAttributes<Log4netTraceListener>();
                IProxyFactory<Foo> proxyFactory = new AttributeProxyFactory<Foo>();

                Foo foo2 = proxyFactory.Create<Log4netTraceListener>();
                foo2.Bar(3);
                foo2.Baz(5888, "hello there", 45.44);
                foo2.FooBaz(5888, "hello there", 45.44, new Temp("ouch"));
            }

            [TestMethod]
            public void Test_method_feature_flag_Successful()
            {
                IProxyFactory<MethodFeatureFlagTest> proxyFactory = new AttributeProxyFactory<MethodFeatureFlagTest>();
                MethodFeatureFlagTest foo = proxyFactory.Create();
                // will only call if exposed but you can still call it
                foo.Foo();
                foo.MyMethodLevelFeature_Method();
            }

            [TestMethod]
            public void Test_class_feature_flag_Successful()
            {
                IProxyFactory<ClassFeatureFlagTest> proxyFactory = new AttributeProxyFactory<ClassFeatureFlagTest>();
                ClassFeatureFlagTest foo = proxyFactory.Create();
                //// will only call if exposed but you can still call it

                foo.Bar();
                foo.Baz();
                foo.Foo();
                string x = "BEFORE";
                x = foo.ToString();                
            }
        }
    }
}
