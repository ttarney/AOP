using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Attributes
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

    public class FeatureClassAttribute : System.Attribute
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
        public FeatureClassAttribute(Type featureType)
        {
            _featureType = featureType;
        }
    }
}
