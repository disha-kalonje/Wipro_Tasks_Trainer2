using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Menu
    {
        static void Main(string[] args)
        {
            int item, quantity;
            char addMore;

            do
            {
                // Display menu
                Console.WriteLine("Select item from Menu:");
                Console.WriteLine("1. Coffee");
                Console.WriteLine("2. Grilled Sandwitch");
                Console.WriteLine("3. French Fries");
                Console.WriteLine("4. Noodles");
                Console.WriteLine("5. Pizza");

                // Get user input for item
                item = GetValidIntegerInput("Enter your choice: ");

                // Get quantity for the chosen item
                // quantity = GetValidIntegerInput("Quantity: ");

                // Display selection confirmation
                Console.WriteLine($"You selected {GetItemName(item)}");

                // Ask if user wants to add more items
                addMore = GetValidCharInput("You want to add more item? (Y/N): ");
            } while (addMore == 'Y' || addMore == 'y');

            // Summarize order
            Console.WriteLine("\nItem selected by you:");
            for (int i = 1; i <= item; i++)
            {
                quantity = GetValidIntegerInput($"Quantity of {GetItemName(i)}: ");
                Console.WriteLine($"{quantity} {GetItemName(i)}");
            }

            Console.WriteLine("Total Items Ordered: {0}", item);
        }

        static int GetValidIntegerInput(string message)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value));
            return value;
        }

        static char GetValidCharInput(string message)
        {
            char input;
            do
            {
                Console.Write(message);
                input = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Move to next line after input
            } while (input != 'Y' && input != 'y' && input != 'N' && input != 'n');
            return input;
        }

        static string GetItemName(int itemNumber)
        {
            switch (itemNumber)
            {
                case 1:
                    return "Coffee";
                case 2:
                    return "Grilled Sandwich";
                case 3:
                    return "French Fries";
                case 4:
                    return "Noodles";
                case 5:
                    return "Pizza";
                default:
                    return "Unknown Item";
            }
        }
    }
}
