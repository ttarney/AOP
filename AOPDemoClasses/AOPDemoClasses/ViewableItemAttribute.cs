using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Delegate | AttributeTargets.Interface)]
//    public sealed class ViewIntellisenseAttribute : Attribute
//    {
//        private EditorBrowsableState browsableState;


//        /// <devdoc>
//        ///    <para>[To be supplied.]</para>
//        /// </devdoc>
//        public ViewIntellisenseAttribute(string featureName)
//        {
//            FeatureToggleEntities db = new FeatureToggleEntities();
//            using (StreamWriter writer = new StreamWriter(@"c:\development\attribute.txt", true))
//            {
//                writer.WriteLine("in attribute");
//            }
//            Feature feature = db.Features.Where(f => f.Feature1 == featureName).FirstOrDefault();
//            if(feature.Enabled)
//            {
//                browsableState = EditorBrowsableState.Always;
//            }
//            else
//            {
//                browsableState = EditorBrowsableState.Never;
//            }
            
//        }

//        /// <devdoc>
//        ///    <para>[To be supplied.]</para>
//        /// </devdoc>
//        public ViewIntellisenseAttribute()
//        {
//            using (StreamWriter writer = new StreamWriter(@"c:\development\attribute.txt", true))
//            {
//                writer.WriteLine("in attribute");
//            }
//            browsableState = EditorBrowsableState.Always;
//        }

//        /// <devdoc>
//        ///    <para>[To be supplied.]</para>
//        /// </devdoc>
//        public EditorBrowsableState State
//        {
//            get { return browsableState; }
//        }

//        public override bool Equals(object obj)
//        {
//            if (obj == this)
//            {
//                return true;
//            }

//            ViewIntellisenseAttribute other = obj as ViewIntellisenseAttribute;

//            return (other != null) && other.browsableState == browsableState;
//        }

//        public override int GetHashCode()
//        {
//            return base.GetHashCode();
//        }
//    }

//    /// <devdoc>
//    ///    <para>[To be supplied.]</para>
//    /// </devdoc>
//    public enum EditorBrowsableState
//    {
//        /// <devdoc>
//        ///    <para>[To be supplied.]</para>
//        /// </devdoc>
//        Always,
//        /// <devdoc>
//        ///    <para>[To be supplied.]</para>
//        /// </devdoc>
//        Never,
//        /// <devdoc>
//        ///    <para>[To be supplied.]</para>
//        /// </devdoc>
//        Advanced
//    }
//}
