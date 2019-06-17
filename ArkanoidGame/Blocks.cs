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
            this.x = x;
            this.y = y;
            h = 30;
            w = 30;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImagePart(image, 0, 0, h, w, x, y);
        }

        public override void Update(GameEngine engine)
        {
           
        }
    }
}
