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
        string picturesFile = "sprites.png";
        public ArkanoidGameEngine(ConsoleGraphics graphics)
        : base(graphics)
        {
            AddObject(new Board(graphics, picturesFile));
            AddObject(new Ball(graphics, picturesFile, this));
            AddObject(new Scors(graphics, picturesFile));
            for (int i = 0; i < 22; i++)
            {
                AddObject(new Blocks(335 + i * 32, 100, graphics, picturesFile));
                AddObject(new Blocks(90 + i * 55, 150, graphics, picturesFile));
                AddObject(new Blocks(190 + i * 45, 250, graphics, picturesFile));
                AddObject(new Blocks(335 + i * 32, 290, graphics, picturesFile));

            }
        }
        
        public List<CGameObject> GetCollisions(CGameObject Obj)
        {
            List<CGameObject> cGameObjects = new List<CGameObject>();

            foreach (CGameObject obj in objects)
            {
                if (obj == Obj) continue;
                if (CGameObject.IsCollision(Obj, obj))
                {
                    cGameObjects.Add(obj);
                }
            }
            return cGameObjects;
        }
        
        protected override int IsGameOver()
        {
            bool isBalls = false;
            bool isBlocks = false;
            foreach (CGameObject obj in objects)
            {
                if (obj is Ball) isBalls = true;
                if (obj is Blocks) isBlocks = true;
            }
            if (!isBalls) return 1;
            if (!isBlocks) return 2;
            return 0;
        }
    }
}
