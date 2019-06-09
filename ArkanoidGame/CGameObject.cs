using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    public abstract class CGameObject : IGameObject
    {
        protected ConsoleImage image;
        protected int x, y;
        protected int h, w;

        public CGameObject(ConsoleGraphics graphics, string img)
        {
            image = graphics.LoadImage(img);
            h = graphics.ClientHeight;
            w = graphics.ClientWidth;
        }

        public virtual void Render(ConsoleGraphics graphics) { }

        public virtual void Update(GameEngine engine) { }
        
    }
}
