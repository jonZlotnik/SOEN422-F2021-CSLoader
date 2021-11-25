// Check if args are there:
if (args == null || args.Length != 2)
{
    Console.Error.WriteLine("ERROR: Not enough arguments.");
    Console.WriteLine("Usage: dotnet run <input.pic> <output.bin>");
    return 1;
}

// Check if file to create exists
if (File.Exists(args[1]))
{
    Console.Error.WriteLine("ERROR: Will not overwrite file.");
    return 1;
}

// Convert file
Console.WriteLine("Converting file to binary...");

using (var outputFile = File.Create(args[1]))
{

    if (File.Exists(args[0]))
    {
        using (StreamReader sr = new StreamReader(args[0]))
        {
            for (string? line; (line = sr.ReadLine()) != null;)
            {
                try
                {
                    int currentInteger = Int32.Parse(line);
                    outputFile.Write(BitConverter.GetBytes(currentInteger));
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("ERROR: Could not parse input file.");
                    return 1;
                }
            }
        }
    }
}

return 0;