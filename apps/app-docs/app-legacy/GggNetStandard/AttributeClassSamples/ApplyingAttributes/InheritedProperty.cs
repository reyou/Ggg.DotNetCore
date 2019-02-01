using System;
using System.Collections.Generic;
using System.Text;

namespace GggNetStandard.AttributeClassSamples.ApplyingAttributes
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes?view=netframework-4.7.1#inherited-property
    /// </summary>
    public class InheritedProperty
    {
        /// <summary>
        /// You can also pass multiple instances of AttributeTargets. 
        /// The following code fragment specifies that a custom attribute 
        /// can be applied to any class or method.
        /// You can specify whether your attribute can be inherited by other classes 
        /// or specify which elements the attribute can be applied to
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
        public class ThisAttribute : Attribute
        {
            //...
        }

        // This defaults to Inherited = true.
        public class MyAttribute : Attribute
        {
            //...
        }

        /// <summary>
        /// You can specify whether your attribute can be inherited by other classes 
        /// or specify which elements the attribute can be applied to
        /// </summary>
        [AttributeUsage(AttributeTargets.Method, Inherited = false)]
        public class YourAttribute : Attribute
        {
            //...
        }

        /// <summary>
        /// The two attributes are then applied to a method in the base class MyClass.
        /// </summary>
        public class MyClass
        {
            [My]
            [Your]
            public virtual void MyMethod()
            {
                //...
            }
        }

        /// <summary>
        /// Finally, the class YourClass is inherited from the base class MyClass. 
        /// The method MyMethod shows MyAttribute, but not YourAttribute. 
        /// Because it has Inherited = false property set.
        /// </summary>
        public class YourClass : MyClass
        {
            // MyMethod will have MyAttribute but not YourAttribute.
            public override void MyMethod()
            {
                //...
            }

        }

    }
}
