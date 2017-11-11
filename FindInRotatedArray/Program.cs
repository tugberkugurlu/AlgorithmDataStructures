using System;

namespace FindInRotatedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArray = new [] {5, 6, 7, 8, 9, 10, 1, 2, 3};
            var key = 3;
            
            Console.WriteLine(FindIndexOfAnElement(inputArray, key));
        }

        /* 
            Search an element in a sorted and rotated array

            Input  : arr[] = {5, 6, 7, 8, 9, 10, 1, 2, 3};
                    key = 3
            Output : Found at index 8
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
    }
}
