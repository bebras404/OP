using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LD5
{
	public static class InOut
	{
		public static StudList ReadStudents(string fileName)
		{
			StudList students = null;
			using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8)) 
			{
				string line;
				int lineCounter = 1;
                line = reader.ReadLine();
                students = new StudList(line);
				while ((line = reader.ReadLine()) != null) 
				{
                    
                    try
					{
                        string[] parts = line.Split(';');
                        string className = parts[0];
                        string name = parts[1];
                        string surname = parts[2];
                        string group = parts[3];

                     
                        Student student = new Student(className, surname, name, group);
                        students.AddClass(student);
                    }
					catch
					{
                        HttpContext.Current.Response.Write(
							String.Format($"<script>alert('Klaida failo" +
							$" {fileName} eilutėje {lineCounter}')</script>")); 
						continue;
                    }
					finally { lineCounter++; }
                }                
            }
            return students;
        }

		public static List<Professor> ReadProfessors(string fileName) 
		{
			List<Professor> profs = null;
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string line;
                int lineCounter = 1;
                profs = new List<Professor>();
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        string[] parts = line.Split(';');
                        string className = parts[0];
                        string name = parts[1];
                        string surname = parts[2];
                        int credits = int.Parse(parts[3]);
                        Professor professor = new Professor(className, surname, name, credits);
                        profs.Add(professor);
                    }
                    catch 
                    {
                        HttpContext.Current.Response.Write(
                            String.Format($"<script>alert('Klaida failo" +
                            $" {fileName} eilutėje {lineCounter}')</script>"));
                        continue;
                    }
                    finally { lineCounter++; }
                }
            }
            return profs;

        }




    }
}