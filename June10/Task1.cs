// Write a function to count the total number of set bits in all integers from 1 to n. (using bitwise operators)

// input -> 3 
// 1:Number of set bit count : Resut_Value 
// 2:Number of set bit count : Result_Value 
// 3:Number of set bit count : Result_Value 

// input -> 6 
// 1:Number of set bit count : Result_Value 
// 2:Number of set bit count : Result_Value 
// 3:Number of set bit count : Result_Value 
// 4:Number of set bit count : Result_Value 
// 5:Number of set bit count : Result_Value 
// 6:Number of set bit count : Result_Value

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetBitCount
{
    public class SetBitCount
    {
        public static int CountTotalSetBits(int n)
        {
            int totalSetBits = 0;

            // Iterate through each number from 1 to n
            for (int i = 1; i <= n; i++)
            {
                // Use Brian Kernighan's algorithm for efficient set bit counting
                int setBits = CountSetBits(i);
                totalSetBits += setBits;
            }

            return totalSetBits;
        }

        // Function to count set bits in a single integer (using Brian Kernighan's algorithm)
        private static int CountSetBits(int x)
        {
            int count = 0;
            while (x != 0)
            {
                count++;
                x &= x - 1; // Clear the rightmost set bit using bitwise AND with (x - 1)
            }
            return count;
        }

        public static void Main(string[] args)
        {
            int n = 8; // Input (change this value to test)

            int totalSetBits = CountTotalSetBits(n);
            Console.WriteLine($"Total number of set bits in all integers from 1 to {n}: {totalSetBits}");

            // Print individual set bit counts for demonstration purposes (optional)
            for (int i = 1; i <= n; i++)
            {
                int setBits = CountSetBits(i);
                Console.WriteLine($"{i}: Number of set bit count: {setBits}");
            }
        }
    }
}
