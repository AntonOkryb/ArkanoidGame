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
            for (int i = 0; i < 1; i++)
            {
                AddObject(new Blocks(170 + i * 45, 100, graphics, "sprites.png"));
                //AddObject(new Blocks(170 + i * 45, 150, graphics, "sprites.png"));
                //AddObject(new Blocks(170 + i * 45, 200, graphics, "sprites.png"));
            }
        }

        public bool isAnyBlockOnBord()
        {
            foreach (var obj in objects)
            {
                if (obj is Blocks)
                {
                    return true;
                }
            }
            return false;
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
