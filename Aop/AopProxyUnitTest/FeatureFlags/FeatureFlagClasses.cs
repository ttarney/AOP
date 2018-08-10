using Core.Attributes;
using FeatureToggle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopProxyUnitTest.FeatureFlags
{
    public class MyMethodLevelFeature : SimpleFeatureToggle
    {
    }

    public class MyClassLevelFeature : SimpleFeatureToggle
    {
    }

    //[FeatureMethod(typeof(MyClassLevelFeature))]
    //public class FeatureClass
    //{

    //}

    public class TempFeatureFlagTest
    {
        [FeatureMethod(typeof(MyMethodLevelFeature))]
        public virtual void MyMethodLevelFeature_Method()
        {
            using (StreamWriter writer = new StreamWriter(@"c:\development\mymethodlevelfeature.txt",true))
            {
                writer.WriteLine("yup");
            }
        }

        public void Foo()
        {
            MyMethodLevelFeature_Method();
        }
    }
}
