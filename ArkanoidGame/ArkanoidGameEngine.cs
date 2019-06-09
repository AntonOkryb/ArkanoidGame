using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    class ArkanoidGameEngine : GameEngine
    {
        public ArkanoidGameEngine(ConsoleGraphics graphics)
        : base(graphics)
        {
            AddObject(new Board(graphics,"sprites.png"));
            AddObject(new Ball(graphics,"sprites.png"));
        }
    }
}
