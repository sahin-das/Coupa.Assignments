namespace Assignment16
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the directory path: ");
            var directoryPath = Console.ReadLine();
            // var directoryPath = @"C:\Users\SahinDas";

            try
            {
                AnalyzeDirectory(directoryPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void AnalyzeDirectory(string directoryPath)
        {
            var files = Directory.GetFiles(directoryPath);
            if (files.Length == 0)
            {
                Console.WriteLine("No files found.");
                return;
            }
            
            Console.WriteLine($"Found {files.Length} files.");
            
            var textFiles = files.Where(f => f.EndsWith(".txt"));
            Console.WriteLine($"TextFiles Found in {directoryPath}: {textFiles.Count()}");
            
            var fileCount = new Dictionary<string, int>();
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

            var fileDetails = files
                .Select(file => new { File = file, Size = new FileInfo(file).Length })
                .OrderByDescending(file => file.Size)
                .Take(5)
                .ToList();
            
            Console.WriteLine("Top 5 largest files found:");
            foreach (var fileDetail in fileDetails)
            {
                Console.WriteLine(fileDetail.File + " (" + fileDetail.Size + " bytes)");
            }
            
            Console.WriteLine("File with maximum length: " + fileDetails[0].File);
        }
    }
}