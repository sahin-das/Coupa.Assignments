namespace Assignment16
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the directory path: ");
            string directoryPath = @"C:\Users\SahinDas";

            try
            {
                AnalyzeDirectory(directoryPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void AnalyzeDirectory(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            if (files.Length == 0)
            {
                Console.WriteLine("No files found.");
                return;
            }
            
            Console.WriteLine($"Found {files.Length} files.");
            
            var textFiles = files.Where(f => f.EndsWith(".txt"));
            Console.WriteLine($"TextFiles Found in {directoryPath}: {textFiles.Count()}");
            
            Dictionary<string, int> fileCount = new Dictionary<string, int>();
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file);
                fileCount.TryGetValue(extension, out var count); 
                fileCount[extension] = count + 1;
            }
            
            Console.WriteLine($"Counts of each extensions:");
            foreach (var keyValuePair in fileCount)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }

            Array.Sort(files, (a, b) => b.Length.CompareTo(a.Length));
            
            Console.WriteLine("Top 5 largest files found:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(files[i] + " (" + files[i].Length + " bytes)");
            }
            
            Console.WriteLine("File with maximum length: " + files[0]);
        }
    }
}