using System;
using System.Collections.Generic;

namespace GggAppDocs.api.system.arraysegment.example3
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.arraysegment-1?view=netframework-4.7.2
    /// </summary>
    public class Example
    {
        public static void Main2()
        {
            String[] names = { "Adam", "Bruce", "Charles", "Daniel",
                "Ebenezer", "Francis", "Gilbert",
                "Henry", "Irving", "John", "Karl",
                "Lucian", "Michael" };
            ArraySegment<string> partNames = new ArraySegment<String>(names, 2, 5);

            // Cast the ArraySegment object to an IList<String> and enumerate it.
            IList<string> list = (IList<String>)partNames;
            for (int ctr = 0; ctr <= list.Count - 1; ctr++)
            {
                Console.WriteLine(list[ctr]);
            }
        }
    }
}
