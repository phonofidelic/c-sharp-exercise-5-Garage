
namespace Garage.UI
{
    public static class ConsoleUI
    {
        public static ConsoleKeyInfo GetSelectionFromReadKey()
        {
            WriteLineInfo($"\nSelect an option from the menu");
            return Console.ReadKey(intercept: true);
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
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }
    }
}
