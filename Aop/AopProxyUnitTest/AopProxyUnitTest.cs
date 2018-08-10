using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;
using Core.Attributes;
using Core.Interceptors;
using ProxyConfiguration;

using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using TraceListeners;
using AopProxyUnitTest.FeatureFlags;
using ProxyFactory;

namespace AopProxyUnitTest
{
    public class Temp
    {
        public string Test;

        public Temp(string test)
        {
            Test = test;
        }

        public override string ToString()
        {
            return Test;
        }
    }

    //[TimeAllMethods(LogTiming = true)]
    public class Foo
    {
        public string X { get; set; }
        public Foo()
        {
            X = "before";
        }

        //[MethodDetailLogging(LogDetail = true)]
        //[MethodTimingAttribute(LogTiming = true)]
        public virtual int FooBaz(int x, string y, double foo, Temp temp)
        {
            System.Threading.Thread.Sleep(1544);
            return 1;
        }

        //[MethodDetailLogging(LogDetail = true)]
        //[MethodTimingAttribute(LogTiming = true)]
        public virtual int Bar(int x)
        {
           // X = "after";
            System.Threading.Thread.Sleep(150);
            return 1;
        }


        [MethodDetailLogging(Property = "X", Stage = "both", LogDetail = true)]
        //[MethodTimingAttribute(LogTiming = true)]
        public virtual int Baz(int x, string y, double foo)
        {
            System.Threading.Thread.Sleep(1000);

            X = "Baz changed X"; 
            return 1;
        }

       

        public override string ToString()
        {
            return X.ToString();
        }
   } 


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
                Foo foo = ProxyFactory.ProxyFactory<Foo>.CreateFromAttributes<Log4netTraceListener>();
                foo.Bar(3);
                foo.Baz(5888, "hello there", 45.44);
                foo.FooBaz(5888, "hello there", 45.44, new Temp("ouch"));
            }

            [TestMethod]
            public void Test_feature_flag_Successful()
            {
                IProxyFactory<TempFeatureFlagTest> proxyFactory = new AttributeProxyFactory<TempFeatureFlagTest>();
                TempFeatureFlagTest foo = proxyFactory.Create();
                // will only call if exposed but you can still call it
                foo.Foo();

                foo.MyMethodLevelFeature_Method();

            }
        }
    }
}
