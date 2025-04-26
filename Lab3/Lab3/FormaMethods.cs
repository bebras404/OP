using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class Forma : System.Web.UI.Page
    {
        /// <summary>
        /// Sets all headers for tables.
        /// </summary>
        /// <param name="headers">Headers in array</param>
        /// <param name="table">Table to set to.</param>

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


        /// <summary>
        /// Adds all data to table.
        /// </summary>
        /// <param name="bonuses">Linked list from which data is added from.</param>

        public void AddDataToThemeTable(ListClass<double> bonuses)
        {
            TableRow row = new TableRow();
            for (bonuses.Start(); bonuses.Exists(); bonuses.Next())
            {
                double curr = bonuses.Get();
                TableCell cell = new TableCell();
                cell.Text = curr.ToString();
                row.Cells.Add(cell);
            }
            PayoutsPerTheme.Rows.Add(row);
        }

        /// <summary>
        /// Adds all data to table.
        /// </summary>
        /// <param name="workers">Linked list from which data is added from.</param>

        public void AddDataFromFile1(ListClass<Employee> workers)
        {
            for (workers.Start(); workers.Exists(); workers.Next())
            {
                TableRow row = new TableRow();
                Employee curr = workers.Get();

                TableCell idCell = new TableCell();
                idCell.Text = curr.Id.ToString();
                row.Cells.Add(idCell);

                TableCell lastNameCell = new TableCell();
                lastNameCell.Text = curr.LastName;
                row.Cells.Add(lastNameCell);

                TableCell firstNameCell = new TableCell();
                firstNameCell.Text = curr.Name;
                row.Cells.Add(firstNameCell);

                TableCell bankNameCell = new TableCell();
                bankNameCell.Text = curr.BankName;
                row.Cells.Add(bankNameCell);

                TableCell bankAccountCell = new TableCell();
                bankAccountCell.Text = curr.AccountNumber;
                row.Cells.Add(bankAccountCell);
                DataFile1.Rows.Add(row);
            }
        }

        /// <summary>
        /// Adds all data to table.
        /// </summary>
        /// <param name="conts">Linked list from which data is added from.</param>

        public void AddDataFromFile2(ListClass<Input> conts)
        {
            for (conts.Start(); conts.Exists(); conts.Next())
            {
                TableRow row = new TableRow();

                Input curr = conts.Get();

                TableCell idCell = new TableCell();
                idCell.Text = curr.Id.ToString();
                row.Cells.Add(idCell);

                for (curr.StartCoef(); curr.ExistsCoef(); curr.NextCoef())
                {
                    TableCell cell = new TableCell();
                    cell.Text = curr.GetCoef().ToString();
                    row.Cells.Add(cell);
                }
                DataFile2.Rows.Add(row);
            }
        }

        /// <summary>
        /// Adds data to Results table.
        /// </summary>
        /// <param name="payoutlist">Linked list from which data is added from.</param>

        public void AddDataToResultsTable(ListClass<Payout> payoutlist, Table table)
        {
            for (payoutlist.Start(); payoutlist.Exists(); payoutlist.Next())
            {
                TableRow row = new TableRow();
                Payout curr = payoutlist.Get();

                TableCell lastNameCell = new TableCell();
                lastNameCell.Text = curr.LastName;
                row.Cells.Add(lastNameCell);

                TableCell firstNameCell = new TableCell();
                firstNameCell.Text = curr.Name;
                row.Cells.Add(firstNameCell);

                for (curr.StartCoef(); curr.ExistsCoef(); curr.NextCoef())
                {
                    TableCell tableCell = new TableCell();
                    tableCell.Text = curr.GetCoef().ToString();
                    row.Cells.Add(tableCell);
                }
                for (curr.StartAmount(); curr.ExistsAmount(); curr.NextAmount())
                {
                    TableCell tableCell = new TableCell();
                    tableCell.Text = curr.GetAmount().ToString();
                    row.Cells.Add(tableCell);
                }
                TableCell SumCell = new TableCell();
                SumCell.Text = curr.Sum.ToString();
                row.Cells.Add(SumCell);
                table.Rows.Add(row);
            }

        }
    }
}