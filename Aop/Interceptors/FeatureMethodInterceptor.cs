using Castle.DynamicProxy;
using Core.Interceptors;
using FeatureToggle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOPInterceptors
{
    public class FeatureMethodInterceptor : BaseInterceptor
    {
        private Type _type;
        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// Allows client to plug in their own handler for the invocation
        /// and testing purposes
        /// </summary>
        public FeatureMethodInterceptor(Type type) : base()
        {
            _type = type;
            // assure we have removed this
            _invocationDelegate = null;
        }

        public FeatureMethodInterceptor(Action<IInvocation> invocationDelegate) : base(invocationDelegate)
        {
        }

        // allow for a delegate to be called if needed instead of 
        // hardcoding what this does
        public override void Intercept(IInvocation invocation)
        {
             IFeatureToggle featureToggle = Activator.CreateInstance(_type) as IFeatureToggle;
            if(featureToggle != null && featureToggle.FeatureEnabled)
             {
                invocation.Proceed();
                return;
            }
        }
    }
}
