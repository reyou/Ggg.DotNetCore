using System;

namespace GggNetStandard.AttributeClassSamples.ApplyingAttributes
{
    public class CustomAttributeExample
    {
        [AttributeUsage(AttributeTargets.All)]
        public class DeveloperAttribute : Attribute
        {
            // Private fields.
            private readonly string _name;
            private readonly string _level;
            private bool _reviewed;

            // This constructor defines two required parameters: name and level.

            public DeveloperAttribute(string name, string level)
            {
                _name = name;
                _level = level;
                _reviewed = false;
            }

            // Define Name property.
            // This is a read-only attribute.

            public virtual string Name => _name;

            // Define Level property.
            // This is a read-only attribute.

            public virtual string Level => _level;

            // Define Reviewed property.
            // This is a read/write attribute.

            public virtual bool Reviewed
            {
                get => _reviewed;
                set => _reviewed = value;
            }
        }

        [Developer("aozdemir", "beginner")]
        public class MyClass
        {

        }

        [Developer("betty", "expert")]
        public class YouClass
        {

        }
    }
}
