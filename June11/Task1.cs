using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June11_task1
{

    public class ParallelFileWrite
    {
        private static readonly string[] FilePaths = { "file1.txt", "file2.txt", "file3.txt" };

        public static async Task WriteNumbersParallelAsync()
        {
            var tasks = new Task[FilePaths.Length];

            for (int i = 0; i < FilePaths.Length; i++)
            {
                int startIndex = (i * 33) + 1; // Distribute numbers evenly (33 per file)
                int endIndex = Math.Min((i + 1) * 33, 100); // Handle the last file's boundary

                tasks[i] = Task.Run(() => WriteToFile(FilePaths[i], startIndex, endIndex));
            }

            await Task.WhenAll(tasks); // Wait for all tasks to finish

            Console.WriteLine("Numbers written to files parallelly.");
        }

        private static void WriteToFile(string filePath, int startIndex, int endIndex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        writer.WriteLine(i);
                    }
                }

                Console.WriteLine($"Successfully wrote to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to {filePath}: {ex.Message}");
            }
        }

        public static void Main(string[] args)
        {
            WriteNumbersParallelAsync().Wait();
        }
    }
}

