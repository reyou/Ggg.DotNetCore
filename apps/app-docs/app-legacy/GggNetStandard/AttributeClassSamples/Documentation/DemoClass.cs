using System;
using System.Reflection;

namespace GggNetStandard.AttributeClassSamples.Documentation
{
    public class DemoClass
    {
        public static void Run(string[] args)
        {
            AnimalTypeTestClass testClass = new AnimalTypeTestClass();
            Type type = testClass.GetType();
            MethodInfo[] methodInfos = type.GetMethods();
            // Iterate through all the methods of the class.
            foreach (MethodInfo mInfo in methodInfos)
            {
                Console.WriteLine("mInfo: {0}", mInfo.Name);
                // Iterate through all the Attributes for each method.
                // Retrieves an array of the custom attributes applied to an assembly, 
                // module, type member, or method parameter
                Attribute[] customAttributes = Attribute.GetCustomAttributes(mInfo);
                Console.WriteLine("customAttributes fetched.");
                foreach (Attribute attr in customAttributes)
                {
                    // Check for the AnimalType attribute.
                    if (attr.GetType() == typeof(AnimalTypeAttribute))
                    {
                        Console.WriteLine("Method {0} has a pet {1} attribute.", mInfo.Name, ((AnimalTypeAttribute)attr).Pet);
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n===qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq===\n");
            testClass.DogMethod();
            testClass.CatMethod();
            testClass.BirdMethod();
        }
    }
}