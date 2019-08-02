using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    class Board : CGameObject
    {
        
        public Board(ConsoleGraphics graphics, string img) : base(graphics, img)
        {
            X = 600;
            Y = 745;
            H = 25;
            W = 116;
        }

        public override void Render(ConsoleGraphics graphics)
        {
                graphics.DrawImagePart(image, 0, 240, W, H, X, Y);
        }

        public override void Update(GameEngine engine)
        {
                int W = graphics.ClientWidth;
                int H = graphics.ClientHeight;

                if (X < W - 125)
                    if (Input.IsKeyDown(Keys.RIGHT)) X += 25;

                if (X > 0)
                    if (Input.IsKeyDown(Keys.LEFT)) X -= 25;
        }
    }
}
