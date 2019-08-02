using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    public class CRect
    {
        public int X1 { set; get; }
        public int Y1 { set; get; }
        public int X2 { set; get; }
        public int Y2 { set; get; }

        public CRect(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }
        public CRect(CPoint a, CPoint b)
        {
            X1 = a.X;
            Y1 = a.Y;
            X2 = b.X;
            Y2 = b.Y;
        }

        public CPoint a
        {
            get
            {
                return new CPoint(X1, Y1);
            }
        }
        public CPoint b
        {
            get
            {
                return new CPoint(X1, Y2);
            }
        }
        public CPoint c
        {
            get
            {
                return new CPoint(X2, Y2);
            }
        }
        public CPoint d
        {
            get
            {
                return new CPoint(X2, Y1);
            }
        }

        public bool IsPiontInside(CPoint p)
        {
            bool okX = X1 <= p.X && p.X <= X2 || X2 <= p.X && p.X <= X1;
            bool okY = Y1 <= p.Y && p.Y <= Y2 || Y2 <= p.Y && p.Y <= Y1;
            return okX && okY;
        }
    }
}
