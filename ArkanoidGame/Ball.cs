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
        private static bool  isGameOver;
        bool noBlocks;

        public Ball(ConsoleGraphics graphics, string img, ArkanoidGameEngine gameEngine) : base(graphics, img)
        {
            isBallStandingOnBoard = true;
            isGameOver = false;
            noBlocks = false;
            x = 649;
            y = 730;
            h = 16;
            w = 16;
            Vx = rnd.Next(-14,-14);
            Vy = -14;
            this.gameEngine = gameEngine;
        }

        public static bool GetIsGameOver()
        {
            return isGameOver;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            if (!isGameOver)
            {
                graphics.DrawImagePart(image, 160, 200, h, w, x, y);
            }
            else
            {
                if (noBlocks)
                {
                    graphics.DrawString("W I N", "Arial", 0xFF000080, 600, 400, 30);
                }
                else
                {
                    graphics.DrawString("G A M E  O V E R", "Arial", 0xFF000080, 500, 400, 30);
                }
                //Program.Run();
            }
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
                        Scors.AddScors(10);
                        noBlocks = gameEngine.isAnyBlockOnBord();
                        if (noBlocks)
                        {
                            isGameOver = true;
                        }
                    }
                }
                if (y > graphics.ClientHeight)
                {
                    isGameOver = true;
                }
            }
        }
    }
}

