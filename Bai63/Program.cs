using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        var dictionary = new Dictionary<string, object>
        {
            { "dien_tich", 12.56 },
            { "chu_vi", 10.24 },
            { "duong_kinh", 4.0 }
        };

        string filePath = "output_systemtextjson.json";
        bool result = WriteDictionaryToJsonFileSystemTextJson(filePath, dictionary);

        Console.WriteLine($"Ghi file thành công: {result}");
    }

    public static bool WriteDictionaryToJsonFileSystemTextJson(string filePath, Dictionary<string, object> dictionary)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(dictionary, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing JSON file: {ex.Message}");
            return false;
        }
    }
}
