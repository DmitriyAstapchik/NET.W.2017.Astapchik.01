using System;
using Sortings;

namespace SortingsTest
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            TestQuicksort(200);
            TestMergeSort(200);

            Console.Read();
        }

        static bool IsSorted(int[] array)
        {
            var sorted = true;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                }
            }

            return sorted;
        }

        static int[] MakeArray()
        {
            var array = new int[rand.Next(10, 100)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next();
            }

            return array;
        }

        static void TestQuicksort(byte times)
        {
            var succeeded = 0;

            for (int i = 0; i < times; i++)
            {
                var array = MakeArray();
                Sorter.Quicksort(array);
                if (IsSorted(array))
                {
                    succeeded++;
                }
            }

            Console.WriteLine($"Quicksort test. Succeeded: {succeeded} of {times}.");
        }

        static void TestMergeSort(byte times)
        {
            var succeeded = 0;

            for (int i = 0; i < times; i++)
            {
                var array = MakeArray();
                if (IsSorted(Sorter.MergeSort(array)))
                {
                    succeeded++;
                }
            }

            Console.WriteLine($"Merge sort test. Succeeded: {succeeded} of {times}.");
        }
    }
}
