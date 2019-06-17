using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    public class CRect
    {
        public int x1 { set; get; }
        public int y1 { set; get; }
        public int x2 { set; get; }
        public int y2 { set; get; }

        public CRect(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
        public CRect(CPoint a, CPoint b)
        {
            x1 = a.x;
            y1 = a.y;
            x2 = b.x;
            y2 = b.y;
        }

        public CPoint a
        {
            get
            {
                return new CPoint(x1, y1);
            }
        }
        public CPoint b
        {
            get
            {
                return new CPoint(x1, y2);
            }
        }
        public CPoint c
        {
            get
            {
                return new CPoint(x2, y2);
            }
        }
        public CPoint d
        {
            get
            {
                return new CPoint(x2, y1);
            }
        }

        public bool IsPiontInside(CPoint p)
        {
            bool okX = x1 <= p.x && p.x <= x2 || x2 <= p.x && p.x <= x1;
            bool okY = y1 <= p.y && p.y <= y2 || y2 <= p.y && p.y <= y1;
            return okX && okY;
        }
    }
}
