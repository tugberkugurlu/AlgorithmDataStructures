using System;

namespace FindInRotatedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArray = new [] {5, 6, 7, 8, 9, 10, 1, 2, 3};
            var key = 6;

            Console.WriteLine(FindIndexOfAnElementBetter(inputArray, key));
        }

        /* 
            Search an element in a sorted and rotated array

            Input  : arr[] = {5, 6, 7, 8, 9, 10, 1, 2, 3};
                    key = 3
            Output : Found at index 8

            https://articles.leetcode.com/searching-element-in-rotated-array/
        */

        private static int FindIndexOfAnElement(int[] array, int key) 
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] == key)
                {
                    return i;
                }
            }

            throw new NotSupportedException();
        } 

        private static int FindIndexOfAnElementBetter(int[] array, int key) 
        {
            int leftMost = 0;
            int rightMost = array.Length - 1;

            while (array[leftMost] > array[rightMost])
            {
                var midPoint = leftMost + (rightMost - leftMost) / 2;
                if(array[midPoint] > array[rightMost]) 
                {
                    leftMost = midPoint + 1;
                }
                else 
                {
                    rightMost = midPoint;
                }
            }

            return leftMost;
        }
    }
}
