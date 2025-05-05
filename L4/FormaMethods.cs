using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace L4
{
	public partial class Forma : System.Web.UI.Page
    { 
        public void LoadDataToTable(Agency agency, HtmlForm form,string header) 
        {
            Table table = new Table();
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell() { Text = string.Format(header), ColumnSpan = 10 });
            table.Rows.Add(headerRow);
            if (agency.Name == string.Empty && agency.Adress == string.Empty) 
            {
                TableRow hRow0 = new TableRow();
                hRow0.Cells.Add(new TableCell() { Text = $"Pavadinimas: {agency.Name}", ColumnSpan = 10 });
                TableRow hRow1 = new TableRow();
                hRow1.Cells.Add(new TableCell() { Text = $"Adresas: {agency.Adress}", ColumnSpan = 10 });
                TableRow hRow2 = new TableRow();
                hRow2.Cells.Add(new TableCell() { Text = $"Telefono numeris: {agency.PhoneNumber}", ColumnSpan = 10 });
                table.Rows.Add(hRow0);
                table.Rows.Add(hRow1);
                table.Rows.Add(hRow2);
            }  
            AddHeader(new string[] {
                "Miestas", "Rajonas", "Gatvė", "Namo numeris", "Tipas",
                "Pastatymo data", "Plotas", "Kambarių skaičius", "Aukštas", "Šildymo tipas" }, table);
            foreach (RealEstate re in agency)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell() { Text = re.City });
                row.Cells.Add(new TableCell() { Text = re.District });
                row.Cells.Add(new TableCell() { Text = re.Street });
                row.Cells.Add(new TableCell() { Text = re.HouseNumber.ToString() });
                row.Cells.Add(new TableCell() { Text = re.Type });
                row.Cells.Add(new TableCell() { Text = re.BuildDate.ToString() });
                row.Cells.Add(new TableCell() { Text = re.Area.ToString() });
                row.Cells.Add(new TableCell() { Text = re.NumberOfRooms.ToString() });
                if (re is Flat flat)
                {
                    row.Cells.Add(new TableCell() { Text = flat.Floor.ToString() });
                    row.Cells.Add(new TableCell() { Text = "-" });
                }
                else if (re is House house)
                {
                    row.Cells.Add(new TableCell() { Text = "-" });
                    row.Cells.Add(new TableCell() { Text = house.HeatingType });
                }
                table.Rows.Add(row);
            }
            form.Controls.Add(table);

        }

        public void LoadMostCommonStreet(Dictionary<string, int> MostCommonStreetEstates, HtmlForm form) 
        {
            Table table = new Table();
            TableRow hRow0 = new TableRow();
            hRow0.Cells.Add(new TableCell() { Text = "Dažniausiai pasikartojantčios gatvės", ColumnSpan = 10 });
            table.Rows.Add(hRow0);
            AddHeader(new string[] { "Gatvės pavadinimas", "Kiekis" }, table);
            foreach (var pair in MostCommonStreetEstates) 
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell() { Text = pair.Key });
                row.Cells.Add(new TableCell() { Text = pair.Value.ToString() });
                table.Rows.Add(row);
            }
            form.Controls.Add(table);
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