using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD5
{
    /// <summary>
    /// Represents a student with class, name, and group information.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The class name.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// The last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The group.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Creates a student with class name, last name, first name, and group.
        /// </summary>
        public Student(string classname, string lastName, string firstName, string group)
        {
            this.ClassName = classname;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Group = group;
        }

        /// <summary>
        /// Creates a student with last name, first name, and group.
        /// </summary>
        public Student(string lastName, string Name, string group)
        {
            this.LastName = lastName;
            this.FirstName = Name;
            this.Group = group;
        }

        /// <summary>
        /// Converts the student data to a table row.
        /// </summary>
        public TableRow ToRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = ClassName });
            row.Cells.Add(new TableCell() { Text = LastName });
            row.Cells.Add(new TableCell() { Text = FirstName });
            row.Cells.Add(new TableCell() { Text = Group });
            return row;
        }

        /// <summary>
        /// Returns a string with student data in table format.
        /// </summary>
        public override string ToString()
        {
            return string.Format($"| {this.ClassName,25} | {this.LastName,25} | {this.FirstName,25} | {this.Group,15} |");
        }
    }
}