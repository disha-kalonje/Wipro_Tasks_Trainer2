using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    internal class Program
    {
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements if they are in wrong order
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = { 10, 50, 90, 40, 30, 20, 80, 70 };

            BubbleSort(arr);

            // Print the sorted array
            Console.WriteLine("Sorted array:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }

    }
}
