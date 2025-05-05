using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4
{
    public class House : RealEstate
    {
        public string HeatingType { get; set; }

        public House(string city, string district, string street, int houseNumber, string type, int buildDate, double area, int numberOfRooms, string HeatingType) :
            base(city, district, street, houseNumber, type, buildDate, area, numberOfRooms)
        {

            this.HeatingType = HeatingType;
        }

        public override bool Equals(object other)
        {
            return this.Equals(other as House);
        }

        public bool Equals(House house)
        {
            if (house == null)
            {
                return false;
            }
            return base.Equals(house);
        }

        public int CompareTo(House house)
        {

            if (this.Area.CompareTo(house.Area) == 0)
            {
                return this.HeatingType.CompareTo(house.HeatingType);
            }
            return this.Area.CompareTo(house.Area);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool IsLarge()
        {
            return this.Area > 200;
        }

        public override string ToString()
        {
            return base.ToString() + $",{this.HeatingType},{"-"}"; ;
        }
    }
}