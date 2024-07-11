using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        float[,] array2D = new float[,]
        {
            { 1.1f, 2.2f, 3.3f },
            { 4.4f, 5.5f, 6.6f },
            { 7.7f, 8.8f, 9.9f }
        };

        string filePath = "output.csv";
        Write2DArrayToCsv(filePath, array2D);

        Console.WriteLine($"Array written to {filePath}");
    }

    public static void Write2DArrayToCsv(string filePath, float[,] array2D)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                int rows = array2D.GetLength(0);
                int cols = array2D.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    string[] rowValues = new string[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        rowValues[j] = array2D[i, j].ToString();
                    }
                    string line = string.Join(",", rowValues);
                    writer.WriteLine(line);
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
