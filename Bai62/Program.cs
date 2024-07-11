using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "path_to_your_json_file.json";
        Dictionary<string, object> dictionary = ReadJsonFileToDictionarySystemTextJson(filePath);

        // Hiển thị kết quả
        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

    public static Dictionary<string, object> ReadJsonFileToDictionarySystemTextJson(string filePath)
    {
        try
        {
            string jsonString = File.ReadAllText(filePath);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            return dictionary;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return null;
        }
    }
}
