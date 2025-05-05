using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace L4
{
    public class Flat : RealEstate
    {
        public int Floor { get; set; }

        public Flat(string city, string district, string street, int houseNumber, string type, int buildDate, double area, int numberOfRooms, int Floor) :
            base(city, district, street, houseNumber, type, buildDate, area, numberOfRooms)
        {

            this.Floor = Floor;
        }

        public override bool Equals(object other)
        {
            return this.Equals(other as Flat);
        }

        public bool Equals(Flat flat)
        {
            if (flat == null)
            {
                return false;
            }
            return base.Equals(flat);
        }

        public int CompareTo(Flat flat)
        {


            if (this.Area.CompareTo(flat.Area) == 0)
            {
                return this.Floor.CompareTo(flat.Floor);
            }
            return this.Area.CompareTo(flat.Area);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool IsLarge()
        {
            return this.Area > 90;
        }

        public override string ToString()
        {
            return base.ToString() + $",{"-"},{this.Floor}";
        }
    }
}