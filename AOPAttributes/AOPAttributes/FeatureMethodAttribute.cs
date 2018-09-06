using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPAttributes
{
    public class FeatureMethodAttribute : System.Attribute
    {
        private Type _featureType;
        public Type FeatureType
        {
            get
            {
                return _featureType;
            }
            set
            {
                _featureType = value;
            }
        }
        public FeatureMethodAttribute(Type featureType)
        {
            _featureType = featureType;
        }
    }
}
