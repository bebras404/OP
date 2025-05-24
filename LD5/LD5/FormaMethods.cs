using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LD5
{
    public partial class Forma : System.Web.UI.Page
    {

        public void LoadDataToTable<T>(ClassList<T> classes, string header, PlaceHolder ph)
        {

            Table table = new Table();
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell() { Text = string.Format(header), ColumnSpan = 4 });
            table.Rows.Add(headerRow);
            TableRow hRow1 = new TableRow();
            hRow1.Cells.Add(new TableCell() { Text = "Modulio pavadinimas" });
            hRow1.Cells.Add(new TableCell() { Text = "Pavardė" });
            hRow1.Cells.Add(new TableCell() { Text = "Vardas" });
            if (typeof(T) == typeof(StudentClasses))
            {
                hRow1.Cells.Add(new TableCell() { Text = "Grupė" });
            }
            else
            {
                hRow1.Cells.Add(new TableCell() { Text = "Kreditų kiekis" });
            }
            table.Rows.Add(hRow1);

            foreach (T c in classes)
            {
                if (typeof(T) == typeof(StudentClasses)) 
                {
                    var s = (StudentClasses)(object)c;
                  
                    table.Rows.Add(s.ToRow());
                }
                if (typeof(T) == typeof(ProfClasses))
                {
                    var p = (ProfClasses)(object)c;
                    table.Rows.Add(p.ToRow());
                }

            }
            ph.Controls.Add(table);

        }

    }


}