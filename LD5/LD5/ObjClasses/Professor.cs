using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD5
{
    /// <summary>
    /// Represents a professor with class name, last name, first name, and credit count.
    /// </summary>
    public class Professor
    {
        /// <summary>
        /// The class name.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// The professor's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The professor's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The credit count.
        /// </summary>
        public int CreditCount { get; set; }

        /// <summary>
        /// Creates a professor with all details.
        /// </summary>
        public Professor(string classname, string lastName, string firstName, int creditCount)
        {
            this.ClassName = classname;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.CreditCount = creditCount;
        }

        /// <summary>
        /// Creates a professor with only last and first name.
        /// </summary>
        public Professor(string lastName, string firstName)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
        }

        /// <summary>
        /// Converts professor data to a table row.
        /// </summary>
        public TableRow ToRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = ClassName });
            row.Cells.Add(new TableCell() { Text = LastName });
            row.Cells.Add(new TableCell() { Text = FirstName });
            row.Cells.Add(new TableCell() { Text = CreditCount.ToString() });
            return row;
        }

        /// <summary>
        /// Returns a formatted string with professor data.
        /// </summary>
        public override string ToString()
        {
            return string.Format($"| {this.ClassName,25} | {this.LastName,25} | {this.FirstName,25} | {this.CreditCount,-15} |");
        }
    }
}