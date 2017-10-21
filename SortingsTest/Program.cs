using System;
using static Sortings.Sorter;

namespace SortingsTest
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            TestSorting(Quicksort, times: 200);
            TestSorting(MergeSort, times: 200);

            Console.Read();
        }

        delegate void Sort(int[] array, int startIndex, int endIndex);

        static void TestSorting(Sort sorting, byte times)
        {
            var succeeded = 0;

            for (int i = 0; i < times; i++)
            {
                var array = MakeArray();
                sorting.Method.Invoke(null, new object[] { array, 0, array.Length - 1 });
                if (IsSorted(array, 0, array.Length - 1))
                {
                    succeeded++;
                }
            }

            Console.WriteLine($"{sorting.Method.Name} test. Succeeded: {succeeded} of {times}.");
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

        static bool IsSorted(int[] array, int startIndex, int endIndex)
        {
            var sorted = true;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                }
            }

            return sorted;
        }
    }
}
