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
            List<StudList> studentsChoises = filePaths.Select(path => InOut.ReadStudents(path)).ToList();
            List<Professor> professors = InOut.ReadProfessors(Server.MapPath("~/ProfData.txt"));
            studentsChoises.ForEach(students =>
            {
                LoadDataToTableStudent(students, $"Fakultetas: {students.GetFaculty()}", PH1);
            });
            LoadDataToTableProfessor(professors, "Profesoriai", PH2);
            Session["students"] = studentsChoises;
            Session["professors"] = professors;
            List<ProfWorkLoad> LoadCalc = TaskUtils.CalculateLoad(professors, studentsChoises);
            LoadDataToTableLoad(LoadCalc, "Dėstytojų darbo apkrovos", PH3);
            Session["Load"] = LoadCalc;

            Button2.Visible = true;
            Label1.Visible = true;
            TextBox1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Name_LastName = TextBox1.Text;
            
        }
    }
}