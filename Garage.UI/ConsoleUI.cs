
namespace Garage.UI
{
    public static class ConsoleUI
    {
        public static int GetSelectionFromReadKey()
        {
            WriteLineInfo($"\nSelect an option from the menu");
            ConsoleKeyInfo input = Console.ReadKey(intercept: true);
            if (input.Key == ConsoleKey.Q)
            {
                return 0;
            }
            string inputString = input.Key.ToString();

            int option;
            var isValidOption = int.TryParse(inputString, out option);
            if (isValidOption) { 
                return option;
            }
            throw new Exception($"'{inputString}' is not a valid option. Please select an available option from the menu.");
        }
        public static void Continue()
        {
            WriteLineInfo("\nPress any key to continue.");
            ReadKey(intercept: true);
        }
        public static void Continue(string message)
        {
            WriteLineInfo(message);
            ReadKey(intercept: true);
        }
        public static string? ReadLine() => Console.ReadLine();
        public static ConsoleKeyInfo ReadKey() => Console.ReadKey();
        public static ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);
        public static void Clear() => Console.Clear();
        public static void Write(string message) => Console.Write(message);
        public static void WriteLine(string message) => Console.WriteLine(message);
        public static void WriteLine() => Console.WriteLine();

        public static void WriteLineInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteException(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
