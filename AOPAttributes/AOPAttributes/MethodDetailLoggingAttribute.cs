using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class MethodDetailLoggingAttribute : ProxyAttributeBase
    {
        public string Name { get; set; }
        public string Property { get; set; }
        public string Stage { get; set; }
        public string FileName { get; set; }
        public string ProxyMethod { get; set; }
        public string RawContent { get; set; }
        public string ProxyParameter { get; set; }

        private bool _logDetail;
        public bool LogDetail
        {
            get { return _logDetail; }
            set { _logDetail = value; }
        }

        public MethodDetailLoggingAttribute()
        {
            _logDetail = false;
        }
    }
}
