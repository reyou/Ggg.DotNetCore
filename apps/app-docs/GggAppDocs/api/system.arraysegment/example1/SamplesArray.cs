using System;

namespace GggAppDocs.api.system.arraysegment.example1
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.arraysegment-1?view=netframework-4.7.2
    /// </summary>
    public class SamplesArray
    {
        public static void Main2()
        {

            // Create and initialize a new string array.
            String[] myArr = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };

            // Display the initial contents of the array.
            Console.WriteLine("The original array initially contains:");
            PrintIndexAndValues(myArr);

            // Define an array segment that contains the entire array.
            ArraySegment<String> myArrSegAll = new ArraySegment<String>(myArr);

            // Display the contents of the ArraySegment.
            Console.WriteLine("The first array segment (with all the array's elements) contains:");
            PrintIndexAndValues(myArrSegAll);

            // Define an array segment that contains the middle five values of the array.
            ArraySegment<String> myArrSegMid = new ArraySegment<String>(myArr, 2, 5);

            // Display the contents of the ArraySegment.
            Console.WriteLine("The second array segment (with the middle five elements) contains:");
            PrintIndexAndValues(myArrSegMid);

            // Modify the fourth element of the first array segment myArrSegAll.
            myArrSegAll.Array[3] = "LION";

            // Display the contents of the second array segment myArrSegMid.
            // Note that the value of its second element also changed.
            Console.WriteLine("After the first array segment is modified, the second array segment now contains:");
            PrintIndexAndValues(myArrSegMid);

        }

        public static void PrintIndexAndValues(ArraySegment<String> arrSeg)
        {
            for (int i = arrSeg.Offset; i < (arrSeg.Offset + arrSeg.Count); i++)
            {
                Console.WriteLine("   [{0}] : {1}", i, arrSeg.Array[i]);
            }
            Console.WriteLine();
        }

        public static void PrintIndexAndValues(String[] myArr)
        {
            for (int i = 0; i < myArr.Length; i++)
            {
                Console.WriteLine("   [{0}] : {1}", i, myArr[i]);
            }
            Console.WriteLine();
        }
    }
}
