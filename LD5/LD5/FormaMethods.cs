using LD5.Lists;
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

        public void LoadDataToTableStudentAfterFilter(ProfClassesList classes, string header, PlaceHolder ph)
        {

            Table table = new Table();
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell() { Text = string.Format(header), ColumnSpan = 4 });
            table.Rows.Add(headerRow);
            TableRow hRow1 = new TableRow();
            hRow1.Cells.Add(new TableCell() { Text = "Modulio pavadinimas" });
            hRow1.Cells.Add(new TableCell() { Text = "Pavardė" });
            hRow1.Cells.Add(new TableCell() { Text = "Vardas" });
            hRow1.Cells.Add(new TableCell() { Text = "Grupė" });
            table.Controls.Add(hRow1);
            for (int i = 0; i < classes.Count(); i++)
            {
                table.Rows.Add(classes.GetClass(i).ToRow());
            }
            ph.Controls.Add(table);

        }


        public void LoadDataToTableStudent(StudList classes, string header, PlaceHolder ph)
        {

            Table table = new Table();
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell() { Text = string.Format(header), ColumnSpan = 4 });
            table.Rows.Add(headerRow);
            TableRow hRow1 = new TableRow();
            hRow1.Cells.Add(new TableCell() { Text = "Modulio pavadinimas" });
            hRow1.Cells.Add(new TableCell() { Text = "Pavardė" });
            hRow1.Cells.Add(new TableCell() { Text = "Vardas" });
            hRow1.Cells.Add(new TableCell() { Text = "Grupė" });
            table.Controls.Add(hRow1);
            for(int i = 0; i < classes.Count(); i++)
            {
                table.Rows.Add(classes.GetClass(i).ToRow());
            }
            ph.Controls.Add(table);

        }

        public void LoadDataToTableProfessor(List<Professor> classes, string header, PlaceHolder ph)
        {

            Table table = new Table();
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell() { Text = string.Format(header), ColumnSpan = 4 });
            table.Rows.Add(headerRow);
            TableRow hRow1 = new TableRow();
            hRow1.Cells.Add(new TableCell() { Text = "Modulio pavadinimas" });
            hRow1.Cells.Add(new TableCell() { Text = "Pavardė" });
            hRow1.Cells.Add(new TableCell() { Text = "Vardas" });
            hRow1.Cells.Add(new TableCell() { Text = "Kreditų kiekis" });
            table.Controls.Add(hRow1);
            foreach (Professor p in classes)
            {
                table.Rows.Add(p.ToRow());
            }
            ph.Controls.Add(table);
        }

        public void LoadDataToTableLoad(List<ProfWorkLoad> loads, string header, PlaceHolder ph)
        {

            Table table = new Table();
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell() { Text = string.Format(header), ColumnSpan = 3 });
            table.Rows.Add(headerRow);
            TableRow hRow1 = new TableRow();
            hRow1.Cells.Add(new TableCell() { Text = "Pavardė" });
            hRow1.Cells.Add(new TableCell() { Text = "Vardas" });
            hRow1.Cells.Add(new TableCell() { Text = "Apkrova" });
            table.Controls.Add(hRow1);
            foreach (ProfWorkLoad l in loads)
            {
                table.Rows.Add(l.ToRow());
            }
            ph.Controls.Add(table);
        }

        public void LoadSessionData() 
        {
            if (Session["students"] != null)
            {
                List<StudList> studentsChoises = (List<StudList>)Session["students"];
                studentsChoises.ForEach(students =>
                {
                    LoadDataToTableStudent(students, $"Fakultetas: {students.GetFaculty()}", PH1);
                });
            }
            if (Session["professors"] != null)
            {
                List<Professor> professors = (List<Professor>)Session["professors"];
                LoadDataToTableProfessor(professors, "Profesoriai", PH2);
            }
            if (Session["Load"] != null)
            {
                List<ProfWorkLoad> LoadCalc = (List<ProfWorkLoad>)Session["Load"];
                LoadDataToTableLoad(LoadCalc, "Dėstytojų darbo apkrovos", PH3);
            }

        }

    }


}