// Inspecting Types at Runtime Modify the previous assignment to inspect a specific type, and print out all of its public properties and fields. Use Type.GetProperty and Type.GetField to retrieve specific members and print out their values for a given instance of the type.

using System;
using System.Reflection;

class ReflectionMemberInspection
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please specify the assembly name and type name as arguments.");
            return;
        }

        string assemblyName = args[0];
        string typeName = args[1];

        try
        {
            // Load the assembly
            Assembly assembly = Assembly.LoadFrom(assemblyName);

            // Get the specific type
            Type targetType = assembly.GetType(typeName);

            if (targetType == null)
            {
                Console.WriteLine($"Error: Type '{typeName}' not found in assembly '{assemblyName}'.");
                return;
            }

            // Inspect public properties
            Console.WriteLine("\nPublic Properties:");
            foreach (PropertyInfo property in targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                Console.WriteLine($"  - Name: {property.Name}");

                // If a getter exists, try to get the property value for an instance
                if (property.CanRead)
                {
                    try
                    {
                        // Create an instance 
                        object instance = Activator.CreateInstance(targetType);
                        object value = property.GetValue(instance);
                        Console.WriteLine($"      Value: {value}");
                    }
                    catch (Exception ex) // Handle exceptions during instance creation or value retrieval
                    {
                        Console.WriteLine($" Error: Could not get property value. Exception: {ex.Message}");
                    }
                }
            }

            // Inspect public fields
            Console.WriteLine("\nPublic Fields:");
            foreach (FieldInfo field in targetType.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                Console.WriteLine($" - Name: {field.Name}");

                try
                {
                    // Get the field value for an instance (if possible)
                    object instance = Activator.CreateInstance(targetType);
                    object value = field.GetValue(instance);
                    Console.WriteLine($" Value: {value}");
                }
                catch (Exception ex) // Handle exceptions during instance creation or value retrieval
                {
                    Console.WriteLine($" Error: Could not get field value. Exception: {ex.Message}");
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: Assembly '{assemblyName}' not found. Exception: {ex.Message}");
        }
        catch (Exception ex) // Catch other exceptions
        {
            Console.WriteLine($"Error: An error occurred while processing the assembly. Exception: {ex.Message}");
        }
    }
}
