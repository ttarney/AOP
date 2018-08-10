using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyConfiguration
{


    [ConfigurationCollection(typeof(InterceptorElement), AddItemName = "interceptor")]
    public class InterceptorsCollection : ConfigurationElementCollection, IEnumerable<InterceptorElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new InterceptorElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            InterceptorElement interceptorElement = element as InterceptorElement;
            return (interceptorElement != null ? interceptorElement.Name : null);
        }

        public InterceptorElement this[int index]
        {
            get
            {
                return BaseGet(index) as InterceptorElement;
            }
        }

        #region IEnumerable<InterceptorElement> Members

        IEnumerator<InterceptorElement> IEnumerable<InterceptorElement>.GetEnumerator()
        {
            return (from index in Enumerable.Range(0, this.Count)
                    select this[index])
                    .GetEnumerator();
        }

        #endregion
    }

    [ConfigurationCollection(typeof(MethodElement), AddItemName = "method")]
    public class MethodsCollection : ConfigurationElementCollection, IEnumerable<MethodElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MethodElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            MethodElement interceptorElement = element as MethodElement;
            return (interceptorElement != null ? interceptorElement.Name : null);
        }

        public MethodElement this[int index]
        {
            get
            {
                return BaseGet(index) as MethodElement;
            }
        }

        #region IEnumerable<InterceptorElement> Members

        IEnumerator<MethodElement> IEnumerable<MethodElement>.GetEnumerator()
        {
            return (from index in Enumerable.Range(0, this.Count)
                    select this[index])
                    .GetEnumerator();
        }

        #endregion
    }

    [ConfigurationCollection(typeof(TypeElement), AddItemName = "type")]
    public class ProxyElementsCollection : ConfigurationElementCollection, IEnumerable<TypeElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            TypeElement typeElement = element as TypeElement;
            return (typeElement != null ? typeElement.Name : null);

        }

        public TypeElement this[int index]
        {
            get
            {
                return BaseGet(index) as TypeElement;
            }
        }

        #region IEnumerable<TypeElement> Members

        IEnumerator<TypeElement> IEnumerable<TypeElement>.GetEnumerator()
        {
            return (from index in
                        Enumerable.Range(0, this.Count)
                    select this[index])
                    .GetEnumerator();
        }

        #endregion
    }
}
