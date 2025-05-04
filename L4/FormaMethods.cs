using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace L4
{
	public partial class Forma : System.Web.UI.Page
    {

        private void LoadSessionData()
        {
            if (Session["Agency1"] is List<RealEstate> ag1)
            {
                AddDataToThemeTable(bonuses);
            }

            if (Session["Agency2"] is List<RealEstate> ag2)
            {
                AddDataFromFile1(workers);
            }

            if (Session["Agency3"] is List<RealEstate> ag3)
            {
                AddDataFromFile2(contributions);
            }           
        }


        public void AddHeader(string[] headers, Table table)
        {
            TableRow headerRow = new TableRow();
            foreach (string header in headers)
            {
                TableCell cell = new TableCell();
                cell.Text = header;
                headerRow.Cells.Add(cell);
            }
            table.Rows.Add(headerRow);
        }

    }


}