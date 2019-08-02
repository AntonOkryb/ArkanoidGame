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

        public CRect(int X1, int Y1, int X2, int Y2)
        {
            X1 = X1;
            Y1 = Y1;
            X2 = X2;
            Y2 = Y2;
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
