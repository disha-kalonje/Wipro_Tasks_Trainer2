// Swap two number in c# using ^ operator without using any third variable.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap_with_Bitwise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 9;
            int b = 10;
            Console.WriteLine($"Before Swapping a = {a}, b = {b}");
            a ^= b;
            b ^= a;
            a ^= b;
            Console.WriteLine($"After Swapping: a = {a}, b = {b}");
        }
    }
}
