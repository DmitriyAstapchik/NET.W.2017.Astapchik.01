using System;

namespace Sortings
{
    public static class Sorter
    {
        static Random rand = new Random();

        public static void Quicksort(int[] array)
        {
            Partition(array, 0, array.Length - 1);
        }

        public static int[] MergeSort(int[] array)
        {
            int[][] subArrays = Divide(array);

            for (int i = 0; i < 2; i++)
            {
                if (subArrays[i].Length > 1)
                {
                    subArrays[i] = MergeSort(subArrays[i]);
                }
            }

            return Merge(subArrays[0], subArrays[1]);
        }

        static void Partition(int[] array, int firstIndex, int lastIndex)
        {
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

        static int[][] Divide(int[] array)
        {
            var leftPart = new int[array.Length / 2];
            var rightPart = new int[array.Length - leftPart.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < leftPart.Length)
                {
                    leftPart[i] = array[i];
                }
                else
                {
                    rightPart[i - leftPart.Length] = array[i];
                }
            }

            return new int[2][] { leftPart, rightPart };
        }

        static int[] Merge(int[] leftPart, int[] rightPart)
        {
            int[] result = new int[leftPart.Length + rightPart.Length];

            for (int i = 0, li = 0, ri = 0; i < result.Length; i++)
            {
                if (li >= leftPart.Length)
                {
                    result[i] = rightPart[ri++];
                }
                else if (ri >= rightPart.Length)
                {
                    result[i] = leftPart[li++];
                }
                else if (leftPart[li] < rightPart[ri])
                {
                    result[i] = leftPart[li++];
                }
                else
                {
                    result[i] = rightPart[ri++];
                }
            }

            return result;
        }
    }
}
