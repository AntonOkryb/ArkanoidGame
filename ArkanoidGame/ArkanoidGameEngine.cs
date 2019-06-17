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
            for (int i = 0; i < 30; i++)
            {
                AddObject(new Blocks( 20 + i*35, 50, graphics, "sprites.png"));
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
