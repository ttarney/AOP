using AOPAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemoClasses
{
    [FeatureClass(typeof(MyClassLevelFeature))]
    public class ClassFeatureFlagTest
    {
        public virtual void Foo()
        {
            Write("Foo");
        }

        public virtual void Bar()
        {
            Write("Bar");
        }
       
        public virtual void Baz()
        {
            Write("Baz");
        }

        private void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(@"c:\development\myclasslevelfeature.txt", true))
            {
                writer.WriteLine(message);
            }
        }

    }
}
