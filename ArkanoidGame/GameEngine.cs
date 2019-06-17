using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ArkanoidGame
{

    public abstract class GameEngine
    {
        private ConsoleGraphics graphics;
        protected List<IGameObject> objects = new List<IGameObject>();
        private List<IGameObject> tempObjects = new List<IGameObject>();
        protected List<IGameObject> delObjects = new List<IGameObject>();

        public GameEngine(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public void AddObject(IGameObject obj)
        {
            tempObjects.Add(obj);
        }

        public void Start()
        {
            while (true)// Game Loop
            {
                foreach (var obj in objects)
                    obj.Update(this);
                foreach (var obj in delObjects)
                {
                    objects.Remove(obj);
                }
                objects.AddRange(tempObjects);
                tempObjects.Clear();

                // clearing screen before painting new frame
                graphics.FillRectangle(0xFF00FF00, 0, 0, graphics.ClientWidth, graphics.ClientHeight);
                
                //painting new frame
                foreach (var obj in objects)
                    obj.Render(graphics);

                // double buffering technique is used
                graphics.FlipPages();

                Thread.Sleep(1);
            }
        }
    }
}
