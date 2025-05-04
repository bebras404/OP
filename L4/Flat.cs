using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4
{
	public class Flat : RealEstate
	{
		public int Floor { get; set; }

		public Flat(string city, string district, string street, int houseNumber, string type, DateTime buildDate, double area, int numberOfRooms, int Floor) :
			base(city, district, street, houseNumber, type, buildDate, area, numberOfRooms) 
		{

			this.City = city;
            this.District = district;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.Type = type;
            this.BuildDate = buildDate;
            this.Area = area;
            this.NumberOfRooms = numberOfRooms;
            this.Floor = Floor;
        }

        public override bool Equals(RealEstate other)
        {
            throw new NotImplementedException();
        }

        public override int CompareTo(RealEstate other)
        {
            throw new NotImplementedException();
        }

        public override bool IsLarge()
        {
            return this.Area > 90;
        }
    }
}