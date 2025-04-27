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
        private ListClass<double> BonusCoef;
        private ListClass<double> BonusAmounts;
        public double Sum { get; set; }

        /// <summary>
        /// Constructor for object.
        /// </summary>
        /// <param name="lastname">Last name of a person.</param>
        /// <param name="name">Name of a person.</param>
        /// <param name="bonusCoef">Linked list for all coeficients.</param>
        /// <param name="bonusAmounts">Linked list for bonus amounts.</param>

        public Payout(string lastname, string name)
        {
            this.LastName = lastname;
            this.Name = name;
            this.BonusCoef = new ListClass<double>();
            this.BonusAmounts = new ListClass<double>();
            this.Sum = 0;
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
            Sum += value;
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

        public override string ToString()
        {
            BonusCoef.Start();
            string firstCoef = BonusCoef.Get().ToString();
            BonusCoef.Next();
            string secondCoef = BonusCoef.Get().ToString();
            BonusCoef.Next();
            string thirdCoef = BonusCoef.Get().ToString();
            BonusCoef.Next();
            string fourthCoef = BonusCoef.Get().ToString();

            BonusAmounts.Start();
            string firstam = BonusAmounts.Get().ToString();
            BonusAmounts.Next();
            string secondam = BonusAmounts.Get().ToString();
            BonusAmounts.Next();
            string thirdam = BonusAmounts.Get().ToString();
            BonusAmounts.Next();
            string fourtham = BonusAmounts.Get().ToString();



            return string.Format($"{LastName,20} | {Name,15} | {firstCoef,-15} | {secondCoef,-15} |" +
                    $" {thirdCoef,-15} | {fourthCoef,-15} | {firstam,-30} | {secondam,-30} |" +
                    $" {thirdam,-30} | {fourtham,-30} | {Sum,-30}");
        }
    }
}