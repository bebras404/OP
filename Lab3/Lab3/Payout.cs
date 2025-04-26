using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    public class Payout : IComparable<Payout>, IEquatable<Payout>
    {
        /// <summary>
        /// Class for Payout object.
        /// </summary>

        public string LastName { get; set; }
        public string Name { get; set; }
        private ListClass<double> BonusCoef { get; }
        private ListClass<double> BonusAmounts { get; }
        public double Sum { get; set; }

        /// <summary>
        /// Constructor for object.
        /// </summary>
        /// <param name="lastname">Last name of a person.</param>
        /// <param name="name">Name of a person.</param>
        /// <param name="bonusCoef">Linked list for all coeficients.</param>
        /// <param name="bonusAmounts">Linked list for bonus amounts.</param>
        public Payout(string lastname, string name, ListClass<double> bonusCoef, ListClass<double> bonusAmounts, double sum)
        {
            this.LastName = lastname;
            this.Name = name;
            this.BonusCoef = bonusCoef;
            this.BonusAmounts = bonusAmounts;
            this.Sum = sum;

        }

        public void StartCoef()
        {
            BonusCoef.Start();
        }

        public bool ExistsCoef()
        {
            return BonusCoef.Exists();
        }

        public void NextCoef()
        {
            BonusCoef.Next();
        }

        public double GetCoef()
        {
            return BonusCoef.Get();
        }

        public void AddCoef(double value)
        {
            BonusCoef.Add(value);
        }

        public void StartAmount()
        {
            BonusAmounts.Start();
        }

        public bool ExistsAmount()
        {
            return BonusAmounts.Exists();
        }

        public void NextAmount()
        {
            BonusAmounts.Next();
        }

        public double GetAmount()
        {
            return BonusAmounts.Get();
        }

        public void AddAmount(double value)
        {
            BonusAmounts.Add(value);
        }


        /// <summary>
        /// Compares node data.
        /// </summary>
        /// <param name="other">Other node data.</param>
        /// <returns>True if they are the same false otherwise.</returns>
        public bool Compare(Payout other)
        {
            if (other.Name == Name && other.LastName == LastName)
            {
                return true;
            }
            return false;
        }

        
        /// <summary>
        /// Compares two node data.
        /// </summary>
        /// <param name="other">Other node data.</param>
        /// <returns></returns>
        public int CompareTo(Payout other)
        {
            int lastNameComp = string.Compare(this.LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
            if (lastNameComp != 0)
            {
                return lastNameComp;
            }

            int nameComp = string.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
            if (nameComp != 0)
            {
                return nameComp;
            }

            return this.Sum.CompareTo(other.Sum);
        }

        public bool Equals(Payout other)
        {
            return this.Name.Equals(other.Name) && this.LastName.Equals(other.LastName);
        }
    }
}