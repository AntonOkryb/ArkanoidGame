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
            x = 600;
            y = 770;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImagePart(image, 0, 240, 116, 25, x, y);
        }

        public override void Update(GameEngine engine)
        {
            if (x < w-125)
                if (Input.IsKeyDown(Keys.RIGHT)) x += 25;

            if (x > 0)
                if (Input.IsKeyDown(Keys.LEFT)) x -= 25;
            
        }


    }
}
