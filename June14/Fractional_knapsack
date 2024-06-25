using System;

namespace FractionalKnapsack
{
    public class FractionalKnapsack
    {
        public static (double[], double) Solve(int[] profits, int[] weights, int capacity)
        {
            if (profits.Length != weights.Length)
            {
                throw new ArgumentException("Profits and weights arrays must have the same length.");
            }

            int numItems = profits.Length;

            // Calculate profit/weight ratios for each item
            double[] ratios = new double[numItems];
            for (int i = 0; i < numItems; i++)
            {
                ratios[i] = (double)profits[i] / weights[i];
            }

            // Sort items in descending order of ratio
            Array.Sort(ratios, profits, (x, y) => y.CompareTo(x));

            // Initialize variables for total profit and fractional quantities
            double totalProfit = 0.0;
            double[] fractionalQuantities = new double[numItems];

            // Fill the knapsack greedily based on ratios
            for (int i = 0; i < numItems; i++)
            {
                if (weights[i] <= capacity)
                {
                    fractionalQuantities[i] = 1.0;
                    totalProfit += profits[i];
                    capacity -= weights[i];
                }
                else
                {
                    fractionalQuantities[i] = (double)capacity / weights[i];
                    totalProfit += ratios[i] * capacity;
                    break;
                }
            }

            return (fractionalQuantities, totalProfit);
        }

        public static void Main(string[] args)
        {
            // Sample data
            int[] profits = { 50, 40, 90, 10, 5, 11, 70, 15 };
            int[] weights = { 3, 4, 6, 4, 1, 2, 5, 2 };
            int capacity = 20;

            // Solve the knapsack problem
            (double[] fractionalQuantities, double totalProfit) = Solve(profits, weights, capacity);

            Console.WriteLine("Fractional quantities:");
            for (int i = 0; i < fractionalQuantities.Length; i++)
            {
                Console.WriteLine($"Item {i + 1}: {fractionalQuantities[i]}");
            }

            Console.WriteLine($"Total profit: {totalProfit}");
        }
    }

}
