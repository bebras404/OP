using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    /// <summary>
    /// Employee object class.
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }

        /// <summary>
        /// Constructor for object.
        /// </summary>
        /// <param name="id">Id of a person.</param>
        /// <param name="lastname">Last name of a person.</param>
        /// <param name="name">Name of a person.</param>
        /// <param name="bankname">Bank name of a person.</param>
        /// <param name="accountnumber">Account number of person.</param>

        public Employee(int id, string lastname, string name, string bankname, string accountnumber)
        {
            this.Id = id;
            this.LastName = lastname;
            this.Name = name;
            this.BankName = bankname;
            this.AccountNumber = accountnumber;
        }

        /// <summary>
        /// ToString override for formatting.
        /// </summary>
        /// <returns>Formatted string.</returns>
        public override string ToString()
        {
            return string.Format($"| {Id,20} | {LastName,-15} | {Name,-15} | {BankName,-15} | {AccountNumber,-20} | ");
        }


    }
}