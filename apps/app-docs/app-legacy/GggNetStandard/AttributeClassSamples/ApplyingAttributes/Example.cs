using System;

namespace GggNetStandard.AttributeClassSamples.ApplyingAttributes
{
    public class Example
    {
        // Specify attributes between square brackets in C#.
        // This attribute is applied only to the Add method.
        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.obsoleteattribute.-ctor?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DEN-US%26k%3Dk(System.ObsoleteAttribute.%2523ctor);k(DevLang-csharp)%26rd%3Dtrue%26f%3D255%26MSPPError%3D-2147217396&view=netframework-4.7.1
        /// Initializes a new instance of the ObsoleteAttribute class with a workaround 
        /// message and a Boolean value indicating whether the obsolete element 
        /// usage is considered an error
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.", false)]
        public static int Add(int a, int b)
        {
            return (a + b);
        }
    }
}
