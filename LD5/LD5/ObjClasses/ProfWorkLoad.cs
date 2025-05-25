using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD5
{
    /// <summary>
    /// Holds information about a professor's workload.
    /// </summary>
    public class ProfWorkLoad
    {
        /// <summary>
        /// Professor's first name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Professor's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Amount of work assigned to the professor.
        /// </summary>
        public int WorkLoad { get; set; }

        /// <summary>
        /// Creates a new ProfWorkLoad with name, last name, and workload.
        /// </summary>
        public ProfWorkLoad(string name, string lastName, int workLoad)
        {
            this.Name = name;
            this.LastName = lastName;
            this.WorkLoad = workLoad;
        }

        /// <summary>
        /// Converts the professor's data to a table row.
        /// </summary>
        public TableRow ToRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = Name });
            row.Cells.Add(new TableCell() { Text = LastName });
            row.Cells.Add(new TableCell() { Text = WorkLoad.ToString() });
            return row;
        }

        /// <summary>
        /// Returns a formatted string with the professor's data.
        /// </summary>
        public override string ToString()
        {
            return string.Format($"| {this.Name,25} | {this.LastName,25} | {this.WorkLoad,-15} |");
        }
    }
}