using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace L4
{
	public abstract class RealEstate : IEquatable<RealEstate>, IComparable<RealEstate>
    {
		public string City { get; set; }
		public string District { get; set; }
		public string Street { get; set; }
        public int HouseNumber { get; set; }
		public string Type { get; set; }
		public DateTime BuildDate { get; set; }
        public double Area { get; set; }
        public int NumberOfRooms { get; set; }

		public RealEstate(string city, string district, string street, int houseNumber, string type, DateTime buildDate, double area, int numberOfRooms) 
		{
			this.City = city;
            this.District = district;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.Type = type;
            this.BuildDate = buildDate;
            this.Area = area;
            this.NumberOfRooms = numberOfRooms;
        }

        public abstract bool Equals(RealEstate other);
        public abstract int CompareTo(RealEstate other);
        public abstract bool IsLarge();
    }
}