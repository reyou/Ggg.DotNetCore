using System;

namespace GggNetStandard.AttributeClassSamples.ApplyingAttributes
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/standard/attributes/retrieving-information-stored-in-attributes?view=netframework-4.7.1
    /// </summary>
    public class RetrievingSingleInstance
    {
        [CustomAttributeExample.Developer("Joan Smith", "42", Reviewed = true)]
        public class MainApp
        {
            public static void Run()
            {
                // Call function to get and display the attribute.
                GetAttribute(typeof(MainApp));
                GetAttributes(typeof(MainApp));
            }

            private static void GetAttribute(Type type)
            {
                // Get instance of the attribute.
                CustomAttributeExample.DeveloperAttribute myAttribute =
                    (CustomAttributeExample.DeveloperAttribute)Attribute.GetCustomAttribute(type, typeof(CustomAttributeExample.DeveloperAttribute));

                if (myAttribute == null)
                {
                    Console.WriteLine("The attribute was not found.");
                }
                else
                {
                    // Get the Name value.
                    Console.WriteLine("The Name Attribute is: {0}.", myAttribute.Name);
                    // Get the Level value.
                    Console.WriteLine("The Level Attribute is: {0}.", myAttribute.Level);
                    // Get the Reviewed value.
                    Console.WriteLine("The Reviewed Attribute is: {0}.", myAttribute.Reviewed);
                }
            }
            private static void GetAttributes(Type type)
            {
                CustomAttributeExample.DeveloperAttribute[] myAttributes =
                    (CustomAttributeExample.DeveloperAttribute[])Attribute.GetCustomAttributes(type, typeof(CustomAttributeExample.DeveloperAttribute));

                if (myAttributes.Length == 0)
                {
                    Console.WriteLine("The attribute was not found.");
                }
                else
                {
                    foreach (CustomAttributeExample.DeveloperAttribute attribute in myAttributes)
                    {
                        // Get the Name value.
                        Console.WriteLine("The Name Attribute is: {0}.", attribute.Name);
                        // Get the Level value.
                        Console.WriteLine("The Level Attribute is: {0}.", attribute.Level);
                        // Get the Reviewed value.
                        Console.WriteLine("The Reviewed Attribute is: {0}.", attribute.Reviewed);
                    }
                }
            }
        }
    }
}
