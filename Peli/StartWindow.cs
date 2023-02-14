namespace Peli
{
    public static class StartWindow
    {
        public static void Start()
        {
            int width = Console.LargestWindowWidth;
            int height = Console.LargestWindowHeight;

            Console.SetBufferSize(width, height);

            string title = "Humans vs Skeletons";

            string pressAnyKey = "Press any KEY to start Humans vs Skeletons!";

            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(pressAnyKey);
            Console.ReadKey();

            Console.Clear();
        }
    }
}
