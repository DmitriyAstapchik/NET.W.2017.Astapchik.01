using System;

namespace Sortings
{
    public static class Sorter
    {
        static Random rand = new Random();

        public static void Quicksort(int[] array)
        {
            ValidateArray(array);

            Partition(array, 0, array.Length - 1);
        }

        public static void Quicksort(int[] array, int startIndex, int endIndex)
        {
            ValidateArray(array);
            ValidateIndices(array, startIndex, endIndex);

            Partition(array, startIndex, endIndex);
        }

        public static void MergeSort(int[] array)
        {
            ValidateArray(array);

            MergeSort(array, 0, array.Length - 1);
        }

        public static void MergeSort(int[] array, int startIndex, int endIndex)
        {
            ValidateArray(array);
            if (array.Length < 2) return;
            ValidateIndices(array, startIndex, endIndex);

            var parts = Divide(startIndex, endIndex);

            foreach (var indices in parts)
            {
                if (indices[1] > indices[0])
                {
                    MergeSort(array, indices[0], indices[1]);
                }
            }

            Merge(array, parts[0], parts[1]);
        }

        static void ValidateArray(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException("Array reference not set to an instance of an array.");
            }
        }

        static void ValidateIndices(int[] array, int startIndex, int endIndex)
        {
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException("Start index out of array range.");
            }

            if (endIndex < 0 || endIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException("End index out of array range.");
            }

            if (endIndex < startIndex)
            {
                throw new ArgumentException("End index lower than start index.");
            }
        }

        static void Partition(int[] array, int firstIndex, int lastIndex)
        {
            if (array.Length < 2) return;

            int lowIndex = firstIndex; // current index for low number
            int highIndex = lastIndex; // current index for high number
            var pivot = array[rand.Next(firstIndex, lastIndex + 1)];

            for (int i = firstIndex; i <= highIndex; i++)
            {
                if (array[i] < pivot)
                {
                    Swap(ref array[i], ref array[lowIndex++]);
                }

                if (array[i] > pivot)
                {
                    Swap(ref array[i--], ref array[highIndex--]);
                }
            }

            if (lowIndex - 1 > firstIndex)
            {
                Partition(array, firstIndex, lowIndex - 1);
            }

            if (highIndex + 1 < lastIndex)
            {
                Partition(array, highIndex + 1, lastIndex);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            if (a != b)
            {
                var temp = a;
                a = b;
                b = temp;
            }
        }

        static int[][] Divide(int firstIndex, int lastIndex)
        {
            var leftPartIndices = new int[2] { firstIndex, firstIndex + (lastIndex - firstIndex) / 2 };
            var rightPartIndices = new int[2] { leftPartIndices[1] + 1, lastIndex };
            return new int[2][] { leftPartIndices, rightPartIndices };
        }

        static void Merge(int[] array, int[] leftPartIndices, int[] rightPartIndices)
        {
            for (int i = leftPartIndices[0]; i <= leftPartIndices[1]; i++)
            {
                for (int j = rightPartIndices[0], k = i; j <= rightPartIndices[1]; j++, k++)
                {
                    if (array[k] > array[j])
                    {
                        Swap(ref array[k], ref array[j]);
                    }
                }
            }
        }
    }
}
