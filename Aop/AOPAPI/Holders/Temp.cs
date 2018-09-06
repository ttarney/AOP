using AOPAttributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOPAPI.Holders
{
    public class Temp
    {
        [MethodTiming(LogTiming = true)]
        public string[] Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
