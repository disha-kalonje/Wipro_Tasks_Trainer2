// Get the count of character in each file using the await and async waiting through task.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class ParallelFileCountChar
{
    static async Task<int> CountCharactersAsync(string fileName)
    {
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                int count = 0;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    count += line.Length;
                }
                return count;
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: File '{fileName}' not found. Exception: {ex.Message}");
            return 0;
        }
    }

    static async Task WriteToFileParallel(string fileName, int start, int end)
    {
        using (StreamWriter writer = new StreamWriter(fileName, true))
        {
            for (int i = start; i <= end; i++)
            {
                await writer.WriteLineAsync(i);
                await Task.Delay(200); // Delay between writes
            }
        }
    }

    static async Task Main(string[] args)
    {
        // Define file paths (modify as needed)
        string file1 = "file1.txt";
        string file2 = "file2.txt";
        string file3 = "file3.txt";

        // Parallel character counting tasks
        Task<int> taskCount1 = CountCharactersAsync(file1);
        Task<int> taskCount2 = CountCharactersAsync(file2);
        Task<int> taskCount3 = CountCharactersAsync(file3);

        // Start all parallel counting tasks
        await Task.WhenAll(taskCount1, taskCount2, taskCount3);

        // Handle potential file not found errors
        int count1 = taskCount1.Result;
        int count2 = taskCount2.Result;
        int count3 = taskCount3.Result;

        // Display character counts
        Console.WriteLine($"Character count for '{file1}': {count1}");
        Console.WriteLine($"Character count for '{file2}': {count2}");
        Console.WriteLine($"Character count for '{file3}': {count3}");

    }
}
