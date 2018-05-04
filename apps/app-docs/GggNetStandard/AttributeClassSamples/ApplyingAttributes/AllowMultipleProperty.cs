using System;

namespace GggNetStandard.AttributeClassSamples.ApplyingAttributes
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes?view=netframework-4.7.1#allowmultiple-property
    /// </summary>
    public class AllowMultipleProperty
    {
        //This defaults to AllowMultiple = false.
        public class MyAttribute : Attribute
        {
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public class YourAttribute : Attribute
        {
        }

        /// <summary>
        /// When multiple instances of these attributes are applied, MyAttribute produces a compiler error. 
        /// The following code example shows the valid use of YourAttribute and the invalid use of MyAttribute.
        /// </summary>
        public class MyClass
        {
            // This produces an error.
            // Duplicates are not allowed.
            // [MyAttribute]
            // [MyAttribute]
            public void MyMethod()
            {
                //...
            }

            // This is valid.
            [Your]
            [Your]
            public void YourMethod()
            {
                //...
            }
        }

    }
}
