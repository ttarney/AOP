using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyConfiguration
{
    public class ProxyConfigSection : ConfigurationSection
    {

        [ConfigurationProperty("types", IsRequired = true)]
        public ProxyElementsCollection ConfigElements
        {
            get
            {
                return base["types"] as ProxyElementsCollection;
            }
        }

        private const string TargetNamespace = "xmlns";
        [ConfigurationProperty(TargetNamespace)]
        public string XmlNamespace
        {
            get
            {
                return (string)this[TargetNamespace];
            }
            set
            {
                this[TargetNamespace] = value;
            }
        }

        private const string XsiNamespace = "xmlns:xsi";
        [ConfigurationProperty(XsiNamespace)]
        public string SchemaNamespace
        {
            get
            {
                return (string)this[XsiNamespace];
            }
            set
            {
                this[XsiNamespace] = value;
            }
        }

    }
}
