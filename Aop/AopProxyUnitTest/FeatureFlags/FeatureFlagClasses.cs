using Core.Attributes;
using FeatureToggle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopProxyUnitTest.FeatureFlags
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFluentInterface
    {
        /// <summary>
        /// Redeclaration that hides the <see cref="object.GetType()"/> method from IntelliSense.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        /// <summary>
        /// Redeclaration that hides the <see cref="object.GetHashCode()"/> method from IntelliSense.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        /// <summary>
        /// Redeclaration that hides the <see cref="object.ToString()"/> method from IntelliSense.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        /// <summary>
        /// Redeclaration that hides the <see cref="object.Equals(object)"/> method from IntelliSense.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);
    }
    public class MyMethodLevelFeature : SqlFeatureToggle
    {
    }


    public class MyClassLevelFeature :  SqlFeatureToggle
    {
    }


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

        public override string ToString()
        {
            return "";
        }

        private void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(@"c:\development\myclasslevelfeature.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }

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
