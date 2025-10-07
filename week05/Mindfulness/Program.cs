using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var menu = new Menu();
            menu.Run();
        }
    }
}
