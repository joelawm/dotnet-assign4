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
        public uint _ownerid;
        public string _streetaddr;
        public string _city;
        public string _state;
        public string _zip;
        public string _forsale;
        public int _housenumber;

        //creating the Community Object
        public Streets(int x, int y, string StreetAddr, string City, string ForSale, string Zip, uint OwnerID , string State, int housenumber)
        {
            _x = x;
            _y = y;
            _streetaddr = StreetAddr;
            _city = City;
            _forsale = ForSale;
            _zip = Zip;
            _ownerid = OwnerID;
            _state = State;
            _housenumber = housenumber;
        }
    }
}
