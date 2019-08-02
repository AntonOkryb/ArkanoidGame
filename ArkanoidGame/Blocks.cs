using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    internal class Blocks : CGameObject
    {
        public Blocks(int x, int y, ConsoleGraphics graphics, string img) : base(graphics, img)
        {
            this.X = x;
            this.Y = y;
            H = 30;
            W = 30;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImagePart(image, 0, 0, H, W, X, Y);

            //if (!Ball.GetIsGameOver())
            //{
            //    graphics.DrawImagePart(image, 0, 0, H, W, X, Y);
            //}
        }

        public override void Update(GameEngine engine)
        {
        }
    }
}
