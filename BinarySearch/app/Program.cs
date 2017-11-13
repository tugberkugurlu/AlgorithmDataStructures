using System;

namespace app
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sortedArray = new [] { 1, 2, 3, 4, 7, 9, 10, 11, 12, 13 };     
            System.Console.WriteLine(FindIndexOfElement(sortedArray, 2));
        }

        public static int FindIndexOfElement(int[] sortedInput, int elementToFind) 
        {
            var p = 0;
            var r = sortedInput.Length;

            while(p <= r) 
            {
                var mid = (p + r) / 2;

                if(sortedInput[mid] == elementToFind)
                    return mid;

                if(sortedInput[mid] > elementToFind) 
                {
                    r = mid - 1;
                }
                else 
                {
                    // sortedInput[mid] < elementToFind
                    p = mid + 1;
                }
            }

            return -1;
        }
    }
}
