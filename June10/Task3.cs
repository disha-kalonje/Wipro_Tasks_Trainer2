// Given an array of integers { 1,2,4,3,3,2,5,1} where every element appears twice except for two (4,5).
// Write a function that finds two non-repeating elements in an Array using bitwise XOR operations.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNonRepeating
{
    public class FindNonRepeating
    {
        public static int[] FindTwoNonRepeating(int[] arr)
        {
            int xor = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                xor ^= arr[i];
            }

            // Find the rightmost set bit in xor
            int rightmostSetBit = xor & ~(xor - 1);

            // Separate elements based on the rightmost set bit
            int a = 0;
            int b = 0;
            foreach (int num in arr)
            {
                if ((num & rightmostSetBit) != 0) // Check if the bit is set
                {
                    a ^= num;
                }
                else
                {
                    b ^= num;
                }
            }

            return new int[] { a, b };
        }

        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 4, 3, 3, 2, 5, 1 };
            int[] nonRepeating = FindTwoNonRepeating(arr);
            Console.WriteLine($"Non-repeating elements: [{nonRepeating[0]}, {nonRepeating[1]}]");
        }
    }
}
