// In end write the data in file by Sync. with delay to 200 millisecond. 

using System;
using System.IO;
using System.Threading.Tasks;

class ParallelFileWriter
{
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

    static async Task WriteToFileSync(string fileName, int start, int end)
    {
        using (StreamWriter writer = new StreamWriter(fileName, true))
        {
            for (int i = start; i <= end; i++)
            {
                writer.WriteLine(i);
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

        // Parallel writing tasks with appropriate ranges to ensure balanced workload
        Task task1 = WriteToFileParallel(file1, 1, 33);
        Task task2 = WriteToFileParallel(file2, 34, 66);
        Task task3 = WriteToFileParallel(file3, 67, 100);

        // Start all parallel writing tasks
        await Task.WhenAll(task1, task2, task3);

        Console.WriteLine("Parallel writing completed.");

        // Sequential writing with delay for demonstration (modify behavior as needed)
        await WriteToFileSync("combined.txt", 1, 100); // Write to a combined file

        Console.WriteLine("Sequential writing completed.");
    }
}
