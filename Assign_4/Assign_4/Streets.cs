using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_4
{
    public class Streets
    {
        public int _x;
        public int _y;
        public string _streetaddr;

        //creating the Community Object
        public Streets(int x, int y, string StreetAddr)
        {
            _x = x;
            _y = y;
            _streetaddr = StreetAddr;
        }
    }
}
