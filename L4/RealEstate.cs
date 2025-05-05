using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace L4
{
    /// <summary>
    /// Represents a real estate with basic details.
    /// </summary>
    public abstract class RealEstate : IEquatable<RealEstate>, IComparable<RealEstate>
    {
        /// <summary>
        /// The city of the real estate.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The district of the real estate.
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// The street of the real estate.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// The house number of the real estate.
        /// </summary>
        public int HouseNumber { get; set; }

        /// <summary>
        /// The type of the real estate (e.g., apartment, house).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The year the real estate was built.
        /// </summary>
        public int BuildDate { get; set; }

        /// <summary>
        /// The size of the real estate in square meters.
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// The number of rooms in the real estate.
        /// </summary>
        public int NumberOfRooms { get; set; }

        /// <summary>
        /// Creates a new real estate with the given details.
        /// </summary>
        public RealEstate(string city, string district, string street, int houseNumber, string type, int buildDate, double area, int numberOfRooms)
        {
            City = city;
            District = district;
            Street = street;
            HouseNumber = houseNumber;
            Type = type;
            BuildDate = buildDate;
            Area = area;
            NumberOfRooms = numberOfRooms;
        }

        /// <summary>
        /// Checks if this real estate is the same as another based on location and size.
        /// </summary>
        public bool Equals(RealEstate other)
        {
            if (other == null) return false;
            if (GetType() != other.GetType()) return false;

            return Street == other.Street && HouseNumber == other.HouseNumber
                && City == other.City && District == other.District && Area == other.Area;
        }

        /// <summary>
        /// Checks if this object is the same as another object.
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as RealEstate);
        }

        /// <summary>
        /// Returns a unique code for the real estate based on its street and house number.
        /// </summary>
        public override int GetHashCode()
        {
            return Street.GetHashCode() ^ HouseNumber.GetHashCode();
        }

        /// <summary>
        /// Compares this real estate to another based on street and house number.
        /// </summary>
        public int CompareTo(RealEstate other)
        {
            if (Street.CompareTo(other.Street) == 0)
            {
                return HouseNumber.CompareTo(other.HouseNumber);
            }
            return Street.CompareTo(other.Street);
        }

        /// <summary>
        /// Returns a string with all the details of the real estate.
        /// </summary>
        public override string ToString()
        {
            return $"{City},{District},{Street},{HouseNumber},{Type},{BuildDate},{Area},{NumberOfRooms}";
        }

        /// <summary>
        /// Checks if the real estate is large based on specific rules.
        /// </summary>
        public abstract bool IsLarge();
    }
}