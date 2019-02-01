using System;

namespace GggNetStandard.AttributeClassSamples.ApplyingAttributes
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes?view=netframework-4.7.1#declaring-the-attribute-class
    /// </summary>
    public class DeclaringAttributeClass
    {
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
        public class MyAttribute : Attribute
        {
            private bool _myvalue;
            private string _myoptional;

            //<snippet15>
            public MyAttribute(bool myvalue)
            {
                _myvalue = myvalue;
            }
            //</snippet15>

            //<snippet16>
            public bool MyProperty
            {
                get => _myvalue;
                set => _myvalue = value;
            }
            //</snippet16>

            public string OptionalParameter
            {
                get => _myoptional;
                set => _myoptional = value;
            }
        }
        // One required (positional) and one optional (named) parameter are applied.
        [My(false, OptionalParameter = "optional data")]
        public class SomeClass
        {
            //...
        }
        // One required (positional) parameter is applied.
        [My(false)]
        public class SomeOtherClass
        {
            //...
        }
    }
}
