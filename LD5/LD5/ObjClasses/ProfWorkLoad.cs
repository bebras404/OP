using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD5
{
	public class ProfWorkLoad
	{
		public string Name { get; set; }
        public string LastName { get; set; }
        public int WorkLoad { get; set; }

        public ProfWorkLoad(string name, string lastName, int workLoad)
        {
            this.Name = name;
            this.LastName = lastName;
            this.WorkLoad = workLoad;
        }

        public TableRow ToRow() 
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = Name });
            row.Cells.Add(new TableCell() { Text = LastName });
            row.Cells.Add(new TableCell() { Text = WorkLoad.ToString() });
            return row;
        }



    }
}