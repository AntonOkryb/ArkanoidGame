using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 150;
            Console.WindowHeight = 40;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();

            GameEngine engine = new ArkanoidGameEngine(graphics);
            engine.Start();
        }
    }
}
