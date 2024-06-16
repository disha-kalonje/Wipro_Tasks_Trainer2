// Write a function to convert the binary string "11100" (28) to equivalent decimal value.

using System;

internal class Program
{
    static void Main(string[] args)
    {
        string binarystring = "11100";
        int decivalue = BinaryToDecimal(binarystring);
        Console.WriteLine(binarystring + "is equal to" + " : " + decivalue);
        Console.ReadKey();
    }
    public static int BinaryToDecimal(string binarystring)
    {
        int decivalue = 0;
        int power = 0;
        
        for (int i = binarystring.Length - 1; i >= 0; i--)
        {
            if (binarystring[i] == '1')
            {
                decivalue += (int)Math.Pow(2, power);
            }
            power++;
        }
        return decivalue;
    }
}
    
