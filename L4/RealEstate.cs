using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing;
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
		public int BuildDate { get; set; }
        public double Area { get; set; }
        public int NumberOfRooms { get; set; }

		public RealEstate(string city, string district, string street, int houseNumber, string type, int buildDate, double area, int numberOfRooms) 
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

        public bool Equals(RealEstate other) 
        {
            if (Object.ReferenceEquals(other, null)) 
            {
                return false;
            }
            if (this.GetType() != other.GetType())
            {
                return false;
            }
            return this.Street == other.Street && this.HouseNumber == other.HouseNumber;
        }
        
        public override bool Equals(object obj)
        {
            return this.Equals(obj as RealEstate);
        }
        public override int GetHashCode()
        {
            return this.Street.GetHashCode() ^ this.HouseNumber.GetHashCode();
        }

        public int CompareTo(RealEstate other) 
        {
            
            if (this.City != (other as RealEstate).City)
            {
                return this.City.CompareTo((other as RealEstate).City);
            }
            if (this.District != (other as RealEstate).District)
            {
                return this.District.CompareTo((other as RealEstate).District);
            }
            if (this.Street != (other as RealEstate).Street)
            {
                return this.Street.CompareTo((other as RealEstate).Street);
            }
            if (this.HouseNumber != (other as RealEstate).HouseNumber)
            {
                return this.HouseNumber.CompareTo((other as RealEstate).HouseNumber);
            }
            return 0;
        }

        public abstract bool IsLarge();
    }
}