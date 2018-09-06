using AOPAttributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemoClasses
{
    public class MethodFeatureFlagTest
    {
        [FeatureMethod(typeof(MyMethodLevelFeature))]
        public virtual void MyMethodLevelFeature_Method()
        {
            Write("yup");
        }

        private void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(@"c:\development\mymethodlevelfeature.txt", true))
            {
                writer.WriteLine(message);
            }
        }

        public void Foo()
        {
            Write("before calling feature method");
            MyMethodLevelFeature_Method();
            Write("after calling feature method");
        }
    }
}
