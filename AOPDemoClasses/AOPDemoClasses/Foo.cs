using AOPAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemoClasses
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


        //[MethodDetailLogging(Property = "X", Stage = "both", LogDetail = true)]
        [MethodTimingAttribute(LogTiming = true)]
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
}
