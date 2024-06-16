using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_index
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Enter elements");
            string input = Console.ReadLine();
            int[] array = Array.ConvertAll(input.Split(''), int.Parse);

            Console.Write("Enter the starting index: ");
            int startIndex = int.Parse(Console.ReadLine());

            Console.Write("Enter the ending index: "); 
            int endIndex = int.Parse(Console.ReadLine());
            
            try {
                int[] slicedArray = SliceArray(array, startIndex, endIndex);

                Console.WriteLine("\nOriginal Array:"); 
                PrintArray(array);

                Console.WriteLine("\nSliced Array:"); 
                PrintArray(slicedArray);
            }
            catch (ArgumentException ex) {
                Console.WriteLine(ex.Message);

            }
        }
    } 
}
