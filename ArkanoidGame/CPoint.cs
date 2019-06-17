using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    public class CPoint
    {
        public int x { set; get; }
        public int y { set; get; }
        public CPoint(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
