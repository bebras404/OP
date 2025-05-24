using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD5
{
	public class StudentClasses
	{
        public string ClassName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
		public string Group { get; set; }

		public StudentClasses(string classname, string lastName, string firstName, string group) 
		{
			this.ClassName = classname;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Group = group;
        }

        public TableRow ToRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = ClassName });
            row.Cells.Add(new TableCell() { Text = LastName });
            row.Cells.Add(new TableCell() { Text = FirstName });
            row.Cells.Add(new TableCell() { Text = Group });
            return row;
        }


    }
}