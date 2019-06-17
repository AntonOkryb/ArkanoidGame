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
        //private ArkanoidGameEngine gameEngine { get; }
       
        private int Vx;
        private int Vy;
        bool isBallStandingOnBoard;

        public Ball(ConsoleGraphics graphics, string img, ArkanoidGameEngine gameEngine) : base(graphics, img)
        {
            isBallStandingOnBoard = true;
            x = 649;
            y = 755;
            h = 16;
            w = 16;
            Vx = rnd.Next(-10,10);
            Vy = -10;
            this.gameEngine = gameEngine;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImagePart(image, 160, 200, h, w, x, y);
        }

        public override void Update(GameEngine engine)
        {
            int W = graphics.ClientWidth;
            int H = graphics.ClientHeight;
            if (isBallStandingOnBoard)
            {
                if (x < W - 70)
                    if (Input.IsKeyDown(Keys.RIGHT)) x += 25;

                if (x > 50)
                    if (Input.IsKeyDown(Keys.LEFT)) x -= 25;
            }

            if (Input.IsKeyDown(Keys.UP))
            {
                isBallStandingOnBoard = false;
            }

            if (!isBallStandingOnBoard)
            {
                x += Vx;
                y += Vy;
                if (x <= 0 || x >= W-5 ) Vx = -Vx;
                if (y <= 0 ) Vy = -Vy;
                List<CGameObject> gameObjects = gameEngine.GetCollisions(this);
                foreach (var gO in gameObjects)
                {
                    if (gO is Board)
                    {
                        Vy = -Vy;
                    }
                    if (gO is Blocks)
                    {
                        Vy = -Vy;
                        gameEngine.removeGameObj(gO);
                    }
                }
            }
        }
            
    }
}

