using LD5.Lists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD5
{
    public partial class Forma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button2.Visible = false;
                Label1.Visible = false;
                TextBox1.Visible = false;
                if (File.Exists(Server.MapPath("~/ExternalData.txt"))) File.Delete(Server.MapPath("~/ExternalData.txt"));
            }
            else
            {
                LoadSessionData();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/AppData/");
            string[] filePaths = Directory.GetFiles(folderPath, "*.txt");
            List<StudList> studentsChoises = new List<StudList>();
            List<Professor> professors = new List<Professor>();
            if (filePaths.Length == 0)
            {
                HttpContext.Current.Response.Write("<script>alert('Nerasta jokių failų AppData aplanke.')</script>");
                return;
            }
            try
            {
                studentsChoises = filePaths.Select(path => InOut.ReadStudents(path)).ToList();
                InOut.WriteToFileStudents(Server.MapPath("~/ExternalData.txt"), studentsChoises, "Nuskaityti studentų duomenys");
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Klaida skaitant studentų duomenis. Patikrinkite failus AppData aplanke.')</script>");
            }
            try
            {
               professors = InOut.ReadProfessors(Server.MapPath("~/ProfData.txt"));
                InOut.WriteToFileProfessors(Server.MapPath("~/ExternalData.txt"), professors, "Nuskaityti dėstytojų duomenys");
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Klaida skaitant dėstytojų duomenis. Patikrinkite ProfData.txt failą.')</script>");
                return;
            }


            studentsChoises.ForEach(students =>
            {
                LoadDataToTableStudent(students, $"Fakultetas: {students.GetFaculty()}", PH1);
            });


            LoadDataToTableProfessor(professors, "Profesoriai", PH2);
            Session["students"] = studentsChoises;
            Session["professors"] = professors;
            List<ProfWorkLoad> LoadCalc = new List<ProfWorkLoad>();
            try
            {
                LoadCalc = TaskUtils.CalculateLoad(professors, studentsChoises);
                InOut.WriteToFileWorkLoads(Server.MapPath("~/ExternalData.txt"), LoadCalc, "Dėstytojų darbo apkrovos");
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Klaida skaičiuojant dėstytojų apkrovą.')</script>");
                return;
            }
            LoadDataToTableLoad(LoadCalc, "Dėstytojų darbo apkrovos", PH3);
            Session["Load"] = LoadCalc;

            Button2.Visible = true;
            Label1.Visible = true;
            TextBox1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Name_LastName = TextBox1.Text.Trim();
            List<Professor> filteredProfessors = TaskUtils.FilterProfessorsByName(Name_LastName, (List<Professor>)Session["professors"]);
            List<ProfClassesList> filteredByClass = TaskUtils.TakeClassesByName(filteredProfessors, (List<StudList>)Session["students"]);
            filteredByClass.ForEach(ProfClass =>
            {
                LoadDataToTableStudentAfterFilter(ProfClass, "Modulio "
                + ProfClass.GetClassName().ToLower() + " studentai, kuriems dėsto " + ProfClass.GetProffessorName() + " : ", PH4);
            });
            InOut.WriteToFileAfterFilter(Server.MapPath("~/ExternalData.txt"), filteredByClass, Name_LastName + " studentai: ");

        }
    }
}