using System;

public class MenuSystem
{
    private static readonly string[] itemArray = { "Coffee", "Grilled Sandwich", "French Fries", "Noodles", "Pizza" };
    private static readonly double[] priceOfItem = { 50.0, 60.0, 100.0, 50.0, 30.0 };

    private static int[] itemPurchased = new int[0]; // Initialize empty array outside the function
    private static int[] itemQuantityPurchased = new int[0]; // Initialize empty array outside the function

    public static void Main(string[] args)
    {
        ShowMenu();
        PurchaseItemAndQuantity();
        CalculateBill();
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Menu:");
        for (int i = 0; i < itemArray.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {itemArray[i]}");
        }
    }

    private static void PurchaseItemAndQuantity()
    {

        char addMore = 'N';
        do
        {
            int item = GetValidIntegerInput("Enter your choice: ");
            item--; // Adjust for 0-based indexing

            if (item < 0 || item >= itemArray.Length)
            {
                Console.WriteLine("Invalid item selection. Please try again.");
                continue;
            }

            int quantity = GetValidIntegerInput("Quantity: ");

            itemPurchased = AddToArray(itemPurchased, item);
            itemQuantityPurchased = AddToArray(itemQuantityPurchased, quantity);

            Console.WriteLine($"You selected {quantity} {itemArray[item]}");

            addMore = GetValidCharInput("You want to add more item? (Y/N): ");
        } while (addMore == 'Y' || addMore == 'y');
    }

    private static int GetValidIntegerInput(string message)
    {
        int value;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out value));
        return value;
    }

    private static char GetValidCharInput(string message)
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

    private static int[] AddToArray(int[] array, int value)
    {
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = value;
        return array;
    }

    private static void CalculateBill()
    {
        double totalBill = 0.0;
        for (int i = 0; i < itemPurchased.Length; i++)
        {
            totalBill += priceOfItem[itemPurchased[i]] * itemQuantityPurchased[i];
        }

        Console.WriteLine("\nYour Order:");
        for (int i = 0; i < itemPurchased.Length; i++)
        {
            Console.WriteLine($"{itemQuantityPurchased[i]} {itemArray[itemPurchased[i]]} - {priceOfItem[itemPurchased[i]] * itemQuantityPurchased[i]:0.00}");
        }
        Console.WriteLine($"Total Bill: {totalBill:0.00}");
    }
}
