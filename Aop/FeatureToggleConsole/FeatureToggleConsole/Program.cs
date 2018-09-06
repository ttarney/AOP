using AOPDemoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureToggleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var savePdfFeature = new MyMethodLevelFeature();

            if (savePdfFeature.FeatureEnabled)
                Console.WriteLine("SaveToPdfFeatureToggle is on");
            else
                Console.WriteLine("SaveToPdfFeatureToggle is off");
        }
    }
}
