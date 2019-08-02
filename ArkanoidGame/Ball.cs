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
       private static Random rnd = new Random();
       
        private int Vx;
        private int Vy;
        private bool isBallStandingOnBoard;
        private int BallCrushedBlocksCnt;

        public Ball(ConsoleGraphics graphics, string img, ArkanoidGameEngine gameEngine) : base(graphics, img)
        {
            isBallStandingOnBoard = true;

            X = 649;
            Y = 730;
            H = 16;
            W = 16;
            Vx = rnd.Next(-14,14);
            Vy = -14;
            this.gameEngine = gameEngine;
            BallCrushedBlocksCnt = 0;
        }

        public override void Render(ConsoleGraphics graphics)
        {
                graphics.DrawImagePart(image, 160, 200, H, W, X, Y);
        }

        public override void Update(GameEngine engine)
        {
            int W = graphics.ClientWidth;
            int H = graphics.ClientHeight;
            if (isBallStandingOnBoard)
            {
                if (X < W - 70)
                    if (Input.IsKeyDown(Keys.RIGHT))
                    {
                        X += 25;
                    }

                if (X > 50)
                    if (Input.IsKeyDown(Keys.LEFT))
                    {
                        X -= 25;
                    }
            }

            if (Input.IsKeyDown(Keys.UP))
            {
                isBallStandingOnBoard = false;
            }

            if (!isBallStandingOnBoard)
            {
                X += Vx;
                Y += Vy;
                if (X <= 0 || X >= W-5 ) Vx = -Vx;
                if (Y <= 0 ) Vy = -Vy;
                bool ballHasChangeDirection = true;
                List<CGameObject> gameObjects = gameEngine.GetCollisions(this);
                foreach (var gO in gameObjects)
                {
                    if (gO is Board)
                    {
                        Vy = -Vy;
                    }
                    if (gO is Blocks)
                    {
                        BallCrushedBlocksCnt++;
                        if (ballHasChangeDirection)
                        {
                            Vy = -Vy;
                        }
                        ballHasChangeDirection = false;
                        gameEngine.RemoveGameObj(gO);
                        Scors.AddScors(10);

                    }
                }
                if (Y > graphics.ClientHeight)
                {
                    gameEngine.RemoveGameObj(this);
                }
            }
        }
    }
}

