using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, double> data = new Dictionary<string, double>
        {
            { "Item1", 123.456 },
            { "Item2", 789.012 },
            { "Item3", 345.678 }
        };

        string filePath = "output.csv";
        WriteDictionaryToCsv(filePath, data);

        Console.WriteLine($"Dictionary written to {filePath}");
    }

    public static void WriteDictionaryToCsv(string filePath, Dictionary<string, double> dictionary)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header
                writer.WriteLine("Key,Value");

                // Write the key-value pairs
                foreach (var kvp in dictionary)
                {
                    writer.WriteLine($"{kvp.Key},{kvp.Value}");
                }
            }
            Console.WriteLine("CSV file written successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing CSV file: {ex.Message}");
        }
    }
}
