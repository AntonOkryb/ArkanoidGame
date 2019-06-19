using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace ArkanoidGame
{
    class GameMenu : CGameObject
    {
        public GameMenu(ConsoleGraphics graphics, string img) : base(graphics, img)
        {
        }

        public override void Render(ConsoleGraphics graphics)
        {
            if (Ball.GetIsGameOver())
            {
                graphics.DrawString("FOR NEW GAME PRESS SPASE\n  FOR EXIT GAME PRESS ESC", "Arial", 0xFF000080, 460, 450, 20); 
                graphics.DrawString("(FOR RESSET BEST SCORS  PRESS (R)","Arial", 0xFF000080, 530, 550, 10);
            }
        }
        public override void Update(GameEngine engine)
        {
            if (Ball.GetIsGameOver())
            {
                if (Input.IsKeyDown(Keys.SPACE)) Program.Run();
                if (Input.IsKeyDown(Keys.ESCAPE))
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                if (Input.IsKeyDown(Keys.KEY_R))
                {
                    Scors.WriteInFileBestScors(0);
                    Scors.SetBestScors(0);
                }
            }
        }
    }
}
