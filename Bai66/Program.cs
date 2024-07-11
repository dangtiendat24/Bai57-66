using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "data.csv";
        bool hasHeader = true;

        double[,] data = ReadCsvTo2DArray(filePath, hasHeader);

        // Print the 2D array
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write(data[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static double[,] ReadCsvTo2DArray(string filePath, bool hasHeader)
    {
        List<double[]> rows = new List<double[]>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool skipHeader = hasHeader;

                while ((line = reader.ReadLine()) != null)
                {
                    if (skipHeader)
                    {
                        skipHeader = false;
                        continue;
                    }

                    string[] values = line.Split(',');
                    double[] row = new double[values.Length];

                    for (int i = 0; i < values.Length; i++)
                    {
                        if (double.TryParse(values[i], out double result))
                        {
                            row[i] = result;
                        }
                        else
                        {
                            throw new FormatException($"Unable to parse '{values[i]}' as a double.");
                        }
                    }

                    rows.Add(row);
                }
            }

            // Convert List to 2D array
            int rowCount = rows.Count;
            int colCount = rows[0].Length;
            double[,] array = new double[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    array[i, j] = rows[i][j];
                }
            }

            return array;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
            return null;
        }
    }
}
