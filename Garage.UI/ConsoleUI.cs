namespace Garage.UI
{
    public static class ConsoleUI
    {
        public static string? ReadLine() => Console.ReadLine();
        public static void Clear() => Console.Clear();
        public static void Write(string message) => Console.Write(message);
        public static void WriteLine(string message) => Console.WriteLine(message);
        public static void WriteLine() => Console.WriteLine();
    }
}
