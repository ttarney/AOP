using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class TimeAllMethodsAttribute : ProxyAttributeBase
    {
        private bool _logTiming;
        public bool LogTiming
        {
            get { return _logTiming; }
            set { _logTiming = value; }
        }


        public TimeAllMethodsAttribute()
        {
            _logTiming = false;
        }
    }

}
