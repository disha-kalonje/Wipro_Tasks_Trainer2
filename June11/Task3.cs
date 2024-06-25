// Read the data from all three files parllely ( File.ReadAllLines(Path)). 

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class ParallelFileReaderWriterRead
{
    static async Task<string[]> ReadFileParallel(string fileName)
    {
        try
        {
            return await Task.Run(() => File.ReadAllLines(fileName));
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: File '{fileName}' not found. Exception: {ex.Message}");
            return Array.Empty<string>();
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
        // Define file paths 
        string file1 = "file1.txt";
        string file2 = "file2.txt";
        string file3 = "file3.txt";

        // Parallel reading tasks
        Task<string[]> task1 = ReadFileParallel(file1);
        Task<string[]> task2 = ReadFileParallel(file2);
        Task<string[]> task3 = ReadFileParallel(file3);

        // Start all parallel reading tasks
        await Task.WhenAll(task1, task2, task3);

        // Handle potential file not found errors
        string[] data1 = task1.Result;
        string[] data2 = task2.Result;
        string[] data3 = task3.Result;

        // Combine data
        string[] combinedData = data1.Concat(data2).Concat(data3).ToArray();

        // Parallel writing tasks with appropriate ranges
        Task taskWrite1 = WriteToFileParallel(file1, 1, data1.Length);
        Task taskWrite2 = WriteToFileParallel(file2, data1.Length + 1, data1.Length + data2.Length);
        Task taskWrite3 = WriteToFileParallel(file3, data1.Length + data2.Length + 1, combinedData.Length);

        // Start all parallel writing tasks
        await Task.WhenAll(taskWrite1, taskWrite2, taskWrite3);

        Console.WriteLine("Parallel reading and writing completed.");
    }
}
