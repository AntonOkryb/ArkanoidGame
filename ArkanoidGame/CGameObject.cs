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
        protected ArkanoidGameEngine gameEngine { get; set; }

        protected ConsoleImage image;
        protected ConsoleGraphics graphics;

        public int X{ set; get; }
        public int Y{ set; get; }
        public int H{ set; get; }
        public int W{ set; get; }
        

        public CGameObject(ConsoleGraphics graphics, string img)
        {
            image = graphics.LoadImage(img);
            this.graphics = graphics;
        }

        public virtual void Render(ConsoleGraphics graphics) { }

        public virtual void Update(GameEngine engine) { }

        public static bool IsCollision(CGameObject A, CGameObject B)
        {
            List<CPoint> pointsA = new List<CPoint>();
            List<CPoint> pointsB = new List<CPoint>();

            pointsA.Add(A.a);
            pointsA.Add(A.b);
            pointsA.Add(A.c);
            pointsA.Add(A.d);
            pointsB.Add(B.a);
            pointsB.Add(B.b);
            pointsB.Add(B.c);
            pointsB.Add(B.d);

            CRect rect1 = A.GetRect();
            CRect rect2 = B.GetRect();

            foreach (var point in pointsA)
            {
                if (rect2.IsPiontInside(point)) return true;
            }

            foreach (var point in pointsB)
            {
                if (rect1.IsPiontInside(point)) return true;
            }

            return false;
        }
        
        public CRect GetRect()
        {
            return new CRect(new CPoint(X, Y), new CPoint(X + W, Y + H));
        }

        public CPoint a
        {
            get
            {
                return new CPoint(X, Y);
            }
        }

        public CPoint b
        {
            get
            {
                return new CPoint(X+W, Y);
            }
        }

        public CPoint c
        {
            get
            {
                return new CPoint(X+W, Y+H);
            }
        }

        public CPoint d
        {
            get
            {
                return new CPoint(X, Y+H);
            }
        }
    }
}
