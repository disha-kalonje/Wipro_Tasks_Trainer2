// Understanding the Basics of Reflection Write a C# console application that uses reflection to list all the types contained in a given assembly. For each type, print out its name, base type, and the interfaces it implements. 

using System;
using System.Reflection;

class ReflectionTypeInfo
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please specify the assembly name as an argument.");
            return;
        }

        string assemblyName = args[0];

        try
        {
            // Load the assembly
            Assembly assembly = Assembly.LoadFrom(assemblyName);

            // Get all types in the assembly
            Type[] types = assembly.GetTypes();

            Console.WriteLine($"Types found in assembly '{assemblyName}':");

            // Iterate through each type
            foreach (Type type in types)
            {
                Console.WriteLine($"\nType: {type.FullName}");

                // Print base type (if any)
                if (type.BaseType != null)
                {
                    Console.WriteLine($" Base Type: {type.BaseType.FullName}");
                }
                else
                {
                    Console.WriteLine(" Base Type: None");
                }

                // Print implemented interfaces
                if (type.GetInterfaces().Length > 0)
                {
                    Console.WriteLine("  Interfaces:");
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        Console.WriteLine($"- {interfaceType.FullName}");
                    }
                }
                else
                {
                    Console.WriteLine("  Interfaces: None");
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: Assembly '{assemblyName}' not found. Exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: An error occurred while processing the assembly. Exception: {ex.Message}");
        }
    }
}
