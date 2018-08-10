using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyConfiguration
{
    public class TypeElement : ConfigurationElement
    {
        [ConfigurationProperty("proxyType", IsKey = false, IsRequired = false)]
        public string ProxyType
        {
            get
            {
                return base["proxyType"] as string;
            }
            set
            {
                base["proxyType"] = value;
            }
        }

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("active", IsKey = false, IsRequired = true)]
        public string Active
        {
            get
            {
                return base["active"] as string;
            }
            set
            {
                base["active"] = value;
            }
        }

        [ConfigurationProperty("interceptors")]
        public InterceptorsCollection Interceptors
        {
            get
            {
                return base["interceptors"] as InterceptorsCollection;
            }
        }
    }

    public class InterceptorElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("active", IsKey = true, IsRequired = true)]
        public bool Active
        {
            get
            {
                return Convert.ToBoolean(base["active"]);
            }
            set
            {
                base["active"] = value;
            }
        }

        [ConfigurationProperty("methods")]
        public MethodsCollection Methods
        {
            get
            {
                return base["methods"] as MethodsCollection;
            }
        }
    }

    public class MethodElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("active", IsKey = true, IsRequired = true)]
        public bool Active
        {
            get
            {
                return Convert.ToBoolean(base["active"]);
            }
            set
            {
                base["active"] = value;
            }
        }

        [ConfigurationProperty("property", IsKey = true, IsRequired = false)]
        public string Property
        {
            get
            {
                return base["property"] as string;
            }
            set
            {
                base["property"] = value;
            }
        }

        [ConfigurationProperty("stage", IsKey = true, IsRequired = false)]
        public string Stage
        {
            get
            {
                return base["stage"] as string;
            }
            set
            {
                base["stage"] = value;
            }
        }

        [ConfigurationProperty("filename", IsKey = true, IsRequired = false)]
        public string FileName
        {
            get
            {
                return base["filename"] as string;
            }
            set
            {
                base["filename"] = value;
            }
        }

        [ConfigurationProperty("proxymethod", IsKey = true, IsRequired = false)]
        public string ProxyMethod
        {
            get
            {
                return base["proxymethod"] as string;
            }
            set
            {
                base["proxymethod"] = value;
            }
        }

        [ConfigurationProperty("rawcontent", IsKey = true, IsRequired = false)]
        public bool RawContent
        {
            get
            {
                return Convert.ToBoolean(base["rawcontent"]);
            }
            set
            {
                base["rawcontent"] = value;
            }
        }

        [ConfigurationProperty("proxyparameter", IsKey = true, IsRequired = false)]
        public string ProxyParameter
        {
            get
            {
                return base["proxyparameter"] as string;
            }
            set
            {
                base["proxyparameter"] = value;
            }
        }


    }
}
