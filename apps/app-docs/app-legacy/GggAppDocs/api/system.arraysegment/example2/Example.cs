using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GggAppDocs.api.system.arraysegment.example2
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.arraysegment-1?view=netframework-4.7.2
    /// </summary>
    public class Example
    {
        private const int SegmentSize = 10;

        public static void Main2()
        {
            List<Task> tasks = new List<Task>();

            // Create array.
            int[] arr = new int[50];
            for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
            {
                arr[ctr] = ctr + 1;
            }

            // Handle array in segments of 10.
            for (int ctr = 1; ctr <= Math.Ceiling((double)arr.Length / SegmentSize); ctr++)
            {
                int multiplier = ctr;
                int elements = (multiplier - 1) * 10 + SegmentSize > arr.Length ?
                    arr.Length - (multiplier - 1) * 10 : SegmentSize;
                ArraySegment<int> segment = new ArraySegment<int>(arr, (ctr - 1) * 10, elements);
                tasks.Add(Task.Run(() =>
                {
                    IList<int> list = segment;
                    for (int index = 0; index < list.Count; index++)
                        list[index] = list[index] * multiplier;
                }));
            }
            try
            {
                Task.WaitAll(tasks.ToArray());
                int elementsShown = 0;
                foreach (var value in arr)
                {
                    Console.Write("{0,3} ", value);
                    elementsShown++;
                    if (elementsShown % 18 == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Errors occurred when working with the array:");
                foreach (var inner in e.InnerExceptions)
                {
                    Console.WriteLine("{0}: {1}", inner.GetType().Name, inner.Message);
                }
            }
        }
    }
}
