using System;
using System.Text;
using System.Text.Json;

class Program
{
    // Hàm tính toán và trả lại JSON string với diện tích, chu vi và đường kính
    static string CalculateCircleProperties(double r)
    {
        double dien_tich = Math.PI * r * r;
        double chu_vi = 2 * Math.PI * r;
        double duong_kinh = 2 * r;

        var result = new
        {
            dien_tich,
            chu_vi,
            duong_kinh
        };

        return JsonSerializer.Serialize(result);
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        double r;
        while (true)
        {
            Console.Write("Nhập bán kính r: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out r) && r > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }
        }

        string jsonResult = CalculateCircleProperties(r);
        Console.WriteLine("Kết quả:");
        Console.WriteLine(jsonResult);
    }
}
