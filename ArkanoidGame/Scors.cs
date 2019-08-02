using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace ArkanoidGame
{
    class Scors : CGameObject
    {
        private static int currentScors;
        private static int bestScors;
        private static bool isBestScorsChenged;
        public Scors(ConsoleGraphics graphics, string img) : base(graphics, img)
        {
            currentScors = 0;
            isBestScorsChenged = false;
            FileInfo scors = new FileInfo("scors.txt");
            if (!scors.Exists)
            {
                using (StreamWriter sw = scors.CreateText())
                {
                    sw.Write(0);
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader("scors.txt"))
                {
                    bestScors = int.Parse(sr.ReadToEnd());
                }
            }
        }

        public void PutBestScors()
        {
                if (currentScors > bestScors)
                {
                    bestScors = currentScors;
                    isBestScorsChenged = true;
                }
            
        }

        public static void WriteInFileBestScors()
        {
            if (isBestScorsChenged)
            {
                using (StreamWriter sw = new StreamWriter("scors.txt", false, System.Text.Encoding.Default))
                {
                    sw.Write(bestScors);
                }
            }
        }

        public static void WriteInFileBestScors(int scors)
        {
            using (StreamWriter sw = new StreamWriter("scors.txt", false, System.Text.Encoding.Default))
            {
                sw.Write(scors);
            }
        }

        public static void SetBestScors(int scors)
        {
            bestScors = scors;
        }

        public static void AddScors(int n)
        {
            currentScors += n;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawString($"SCORS = {currentScors}", "Arial", 0xFF000080, 30, graphics.ClientHeight - 25, 16);
            graphics.DrawString($"BEST SCORS = {bestScors}", "Arial", 0xFF000080, graphics.ClientWidth - 220, graphics.ClientHeight - 25, 16);
        }
        public override void Update(GameEngine engine)
        {
            PutBestScors();
            WriteInFileBestScors();
        }
    }
}
