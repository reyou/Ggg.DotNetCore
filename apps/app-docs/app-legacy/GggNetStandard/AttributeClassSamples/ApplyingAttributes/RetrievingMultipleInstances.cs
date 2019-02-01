using System;
using System.Reflection;

namespace GggNetStandard.AttributeClassSamples.ApplyingAttributes
{
    /// <summary>
    /// Retrieving Multiple Instances of an Attribute Applied to Different Scopes
    /// https://docs.microsoft.com/en-us/dotnet/standard/attributes/retrieving-information-stored-in-attributes?view=netframework-4.7.1#retrieving-multiple-instances-of-an-attribute-applied-to-different-scopes
    /// </summary>
    public class RetrievingMultipleInstances
    {
        public static void GetAttribute(Type t)
        {
            // Get the class-level attributes.

            // Put the instance of the attribute on the class level in the att object.
            var att = (CustomAttributeExample.DeveloperAttribute)Attribute.GetCustomAttribute(t, typeof(CustomAttributeExample.DeveloperAttribute));

            if (att == null)
            {
                Console.WriteLine("No attribute in class {0}.\n", t.ToString());
            }
            else
            {
                Console.WriteLine("The Name Attribute on the class level is: {0}.", att.Name);
                Console.WriteLine("The Level Attribute on the class level is: {0}.", att.Level);
                Console.WriteLine("The Reviewed Attribute on the class level is: {0}.\n", att.Reviewed);
            }

            // Get the method-level attributes.

            // Get all methods in this class, and put them
            // in an array of System.Reflection.MemberInfo objects.
            MethodInfo[] myMemberInfo = t.GetMethods();

            // Loop through all methods in this class that are in the
            // MyMemberInfo array.
            foreach (MethodInfo memberInfo in myMemberInfo)
            {
                att = (CustomAttributeExample.DeveloperAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(CustomAttributeExample.DeveloperAttribute));
                if (att == null)
                {
                    Console.WriteLine("No attribute in member function {0}.\n", memberInfo.ToString());
                }
                else
                {
                    Console.WriteLine("The Name Attribute for the {0} member is: {1}.",
                        memberInfo.ToString(), att.Name);
                    Console.WriteLine("The Level Attribute for the {0} member is: {1}.",
                        memberInfo.ToString(), att.Level);
                    Console.WriteLine("The Reviewed Attribute for the {0} member is: {1}.\n",
                        memberInfo.ToString(), att.Reviewed);
                }
            }
        }
    }
}
