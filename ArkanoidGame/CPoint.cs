using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    public class CPoint
    {
        public int X { set; get; }
        public int Y { set; get; }
        public CPoint(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
    }
}
