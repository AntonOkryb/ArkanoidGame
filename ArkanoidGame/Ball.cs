using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace ArkanoidGame
{
    class Ball : CGameObject
    {
        static Random rnd = new Random();
        private int Vx;
        private int Vy;
        bool isBallStandingOnBoard;
        public Ball(ConsoleGraphics graphics, string img) : base(graphics, img)
        {
            isBallStandingOnBoard = true;
            x = 649;
            y = 745;
            Vx = rnd.Next(-20,20);
            Vy = -20;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImagePart(image, 160, 191, 17, 25, x, y);
        }

        public override void Update(GameEngine engine)
        {
            if (isBallStandingOnBoard)
            {
                if (x < w - 70)
                    if (Input.IsKeyDown(Keys.RIGHT)) x += 25;

                if (x > 50)
                    if (Input.IsKeyDown(Keys.LEFT)) x -= 25;
            }

            if (Input.IsKeyDown(Keys.UP))
                isBallStandingOnBoard = false;

            if (!isBallStandingOnBoard)
            {
                x += Vx;
                y += Vy;
                if (x <= 0 || x >= w-5 ) Vx = -Vx;
                if (y <= 0 ) Vy = -Vy;
            }
        }
    }
}

