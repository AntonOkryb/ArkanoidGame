using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    public class ArkanoidGameEngine : GameEngine
    {

        public ArkanoidGameEngine(ConsoleGraphics graphics)
        : base(graphics)
        {
            AddObject(new Board(graphics, "sprites.png"));
            AddObject(new Ball(graphics, "sprites.png", this));
            AddObject(new Scors(graphics, "sprites.png"));
            AddObject(new GameMenu(graphics, "sprites.png"));
            for (int i = 0; i < 22; i++)
            {
                AddObject(new Blocks(335 + i * 32, 100, graphics, "sprites.png"));
                AddObject(new Blocks(90 + i * 55, 150, graphics, "sprites.png"));
                AddObject(new Blocks(190 + i * 45, 250, graphics, "sprites.png"));
                AddObject(new Blocks(335 + i * 32, 290, graphics, "sprites.png"));

            }
        }
        
        public List<CGameObject> GetCollisions(CGameObject Obj)
        {
            List<CGameObject> cGameObjects = new List<CGameObject>();

            foreach (CGameObject obj in objects)
            {
                if (obj == Obj) continue;
                if (CGameObject.isCollision(Obj, obj))
                {
                    cGameObjects.Add(obj);
                }
            }
            return cGameObjects;
        }
        public void removeGameObj(CGameObject Obj)
        {
            delObjects.Add(Obj);
        }
    }
}
