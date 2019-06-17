using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace ArkanoidGame
{
    class Scors : CGameObject
    {
        private static  int currentScors;
        private int bestScors;
        public Scors(ConsoleGraphics graphics, string img) : base(graphics, img)
        {
            currentScors = 0;
            bestScors = 0;
        }

       public void putBestScors()
        {
            if (currentScors > bestScors)
            {
                bestScors = currentScors;
            }
        }

        public static void AddScors(int n)
        {
            currentScors+=n;
        }

        public static void ScorsReset()
        {
            currentScors=0;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawString($"SCORS = {currentScors}", "Arial", 0xFF000080, 30, graphics.ClientHeight-25, 16);
            graphics.DrawString($"BEST SCORS = {bestScors}", "Arial", 0xFF000080, graphics.ClientWidth - 220, graphics.ClientHeight-25, 16);
        }
        public override void Update(GameEngine engine)
        {
            putBestScors();
        }
    }
}
