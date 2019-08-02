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
            Console.WindowWidth = 170;
            Console.WindowHeight = 50;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            Run();
        }
        public static void Run()
        {
            while (true)
            {
                ConsoleGraphics graphics = new ConsoleGraphics();
                GameEngine engine = new ArkanoidGameEngine(graphics);
                engine.Start();

                graphics.DrawString("FOR NEW GAME PRESS SPASE\n  FOR EXIT GAME PRESS ESC", "Arial", 0xFF000080, 460, 450, 20);
                graphics.DrawString("(FOR RESET BEST SCORS  PRESS (R)", "Arial", 0xFF000080, 530, 550, 10);
                graphics.FlipPages();

                while (Console.KeyAvailable) Console.ReadKey();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.Escape)
                {
                    break;
                }

                if (key == ConsoleKey.R)
                {
                    Scors.WriteInFileBestScors(0);
                    Scors.SetBestScors(0);
                }
            }
        }
    }
}
