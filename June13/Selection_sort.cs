using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    internal class Program
    {

        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // Find the index of the minimum element in unsorted array
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Swap the found minimum element with the first element of unsorted array
                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = { 10, 50, 90, 40, 30, 20, 80, 70 };

            SelectionSort(arr);

            // Print the sorted array (element 20 will be at its sorted position)
            Console.WriteLine("Sorted array:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }
    }
}
