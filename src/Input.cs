using System.Globalization;

namespace VyshKat.App;

public static class Input
{
    public static string ReadCommand()
    {
        return Console.ReadLine()?.Trim() ?? "0";
    }

    public static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value.Trim();
            }

            Console.WriteLine("Введите непустое название.");
        }
    }

    public static int ReadInt(string prompt, int minimum, int maximum)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine();

            if (int.TryParse(value, out int number) &&
                number >= minimum && number <= maximum)
            {
                return number;
            }

            Console.WriteLine($"Введите целое число от {minimum} до {maximum}.");
        }
    }

    public static double ReadPositiveDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine()?.Replace(',', '.');

            if (double.TryParse(value, NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double number) &&
                double.IsFinite(number) && number > 0)
            {
                return number;
            }

            Console.WriteLine("Введите положительное число.");
        }
    }

    public static bool ReadYesNo(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string command = ReadCommand().ToLowerInvariant();

            if (command is "да") return true;
            if (command is "нет") return false;

            Console.WriteLine("Ответьте «да» или «нет».");
        }
    }
}
