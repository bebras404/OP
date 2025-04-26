using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
	public partial class Forma : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTableHeaders();
            LoadSessionData();
        }

        private void SetTableHeaders()
        {
            string[] headers;

            headers = new string[] { "Tema 1", "Tema 2", "Tema 3", "Tema 4" };
            AddHeader(headers, PayoutsPerTheme);

            headers = new string[] { "Asm. k.", "Pavardė", "Vardas", "Bankas", "Banko sąskaita" };
            AddHeader(headers, DataFile1);

            headers = new string[] { "Asm. k.", "Indėlis į tema1", "Indėlis į tema2", "Indėlis į tema3", "Indėlis į tema4" };
            AddHeader(headers, DataFile2);

            headers = new string[] { "Pavardė", "Vardas", "Indėlis į tema1",
                "Indėlis į tema2", "Indėlis į tema3", "Indėlis į tema4", "Bonusas už tema 1", "Bonusas už tema 2",
                "Bonusas už tema 3", "Bonusas už tema 4", "Bonusų suma" };
            AddHeader(headers, Results);
            AddHeader(headers, LessAvg);
        }

        private void LoadSessionData()
        {
            if (Session["Bonuses"] is ListClass<double> bonuses)
            {
                AddDataToThemeTable(bonuses);
            }

            if (Session["Workers"] is ListClass<Employee> workers)
            {
                AddDataFromFile1(workers);
            }

            if (Session["Contributions"] is ListClass<Input> contributions)
            {
                AddDataFromFile2(contributions);
            }

            if (Session["Payouts"] is ListClass<Payout> payouts)
            {
                AddDataToResultsTable(payouts, Results);
            }

            if (Session["Less"] is ListClass<Payout> LessThanAverage)
            {
                AddDataToResultsTable(LessThanAverage, LessAvg);
            }
        }

        protected void Upload1_Click(object sender, EventArgs e)
        {
            ListClass<double>  bonuses = new ListClass<double>();
            ListClass<Employee> workers = new ListClass<Employee>();
            ListClass<Input> contributions = new ListClass<Input>();

            if (FileUpload1.HasFile)
            {
                workers = InOutUtils.ReadWorkers(FileUpload1.FileContent);
                Session["Workers"] = workers;
            }

            if (FileUpload2.HasFile)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    FileUpload2.FileContent.CopyTo(memStream);
                    memStream.Position = 0;

                    using (MemoryStream firstReadStream = new MemoryStream(memStream.ToArray()))
                    {
                        contributions = InOutUtils.ReadContributions(firstReadStream);
                        Session["Contributions"] = contributions;
                    }

                    memStream.Position = 0;

                    using (MemoryStream secondReadStream = new MemoryStream(memStream.ToArray()))
                    {
                        bonuses = InOutUtils.ReadBonusAmounts(secondReadStream);
                        Session["Bonuses"] = bonuses;
                    }
                }
            }

            AddDataToThemeTable(bonuses);
            AddDataFromFile1(workers);
            AddDataFromFile2(contributions);
            ListClass<Payout> payoutsList = TaskUtils.AddToList(contributions, workers);
            ListClass<Payout> payouts = TaskUtils.CalculateBonus(payoutsList, bonuses, contributions);
            //payouts.Sort();
            Session["Payouts"] = payouts;
            AddDataToResultsTable(payouts, Results);
            double avg = TaskUtils.CalculateAveragePayout(payouts);
            ListClass<Payout> LessThanAverage = TaskUtils.LessThanAvarage(payouts, avg);
           // LessThanAverage.Sort();
           Session["Less"] = LessThanAverage;

            AddDataToResultsTable(LessThanAverage, LessAvg);
            string basepath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(basepath, "ExternalData.txt");
            if (File.Exists(filePath)) { File.Delete(filePath); }
            InOutUtils.WriteToFileBonus(filePath, bonuses, "Premijų sumos: ");
            InOutUtils.WriteToFileWorkers(filePath, workers, "Darbuotojai: ");
            InOutUtils.WriteToFileInput(filePath, contributions, "Indėliai: ");
            InOutUtils.WriteToFileCalculations(filePath, payouts, "Išmokėjimai: ");
            InOutUtils.WriteToFileCalculations(filePath, LessThanAverage, "Darbuotojai uždirbę mažiau nei premijų vidurkis: ");

        }

        protected void Pick_Click(object sender, EventArgs e)
        {

        }
    }
}