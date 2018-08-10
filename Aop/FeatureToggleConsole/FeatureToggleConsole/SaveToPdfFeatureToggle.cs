using Core.Attributes;
using FeatureToggle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureToggleConsole
{
    public class MyMethodLevelFeature :  SimpleFeatureToggle
    {
    }

    public class MyClassLevelFeature : SimpleFeatureToggle
    {
    }

    [FeatureMethod(typeof(MyClassLevelFeature))]
    public class FeatureClass
    {

    }

    public class Temp
    {
        [FeatureMethod(typeof(MyMethodLevelFeature))]
        public void FeatureMethod()
        {

        }
        
        public void Foo()
        {
            FeatureMethod();
        }
    }
}
