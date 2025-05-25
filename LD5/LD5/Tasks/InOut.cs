using LD5.Lists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LD5
{
    /// <summary>
    /// Handles reading and writing student and professor data to files.
    /// </summary>
    public static class InOut
    {
        /// <summary>
        /// Reads students from a file and returns a StudList.
        /// </summary>
        /// <param name="fileName">The file to read from.</param>
        /// <returns>List of students.</returns>
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
                        string lastname = parts[1];
                        string name = parts[2];
                        string group = parts[3];

                        Student student = new Student(className, lastname, name, group);
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

        /// <summary>
        /// Reads professors from a file and returns a list of Professor objects.
        /// </summary>
        /// <param name="fileName">The file to read from.</param>
        /// <returns>List of professors.</returns>
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
                        string lastname = parts[1];
                        string name = parts[2];
                        int credits = int.Parse(parts[3]);
                        Professor professor = new Professor(className, lastname, name, credits);
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

        /// <summary>
        /// Writes a list of student lists to a file with a header.
        /// </summary>
        /// <param name="fileName">The file to write to.</param>
        /// <param name="list">List of student lists.</param>
        /// <param name="header">Header text.</param>
        public static void WriteToFileStudents(string fileName, List<StudList> list, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(header);
                foreach (StudList studList in list)
                {
                    writer.WriteLine("Fakultetas: " + studList.GetFaculty());
                    writer.WriteLine(new string('-', 103));
                    writer.WriteLine($"| {"Modulio pavadinimas",25} | {"Pavardė",25} | {"Vardas",25} | {"Grupė",15} |");
                    writer.WriteLine(new string('-', 103));
                    foreach (Student s in studList)
                    {
                        writer.WriteLine(s.ToString());
                    }
                    writer.WriteLine(new string('-', 103));
                }
            }
        }

        /// <summary>
        /// Writes a list of professors to a file with a header.
        /// </summary>
        /// <param name="fileName">The file to write to.</param>
        /// <param name="list">List of professors.</param>
        /// <param name="header">Header text.</param>
        public static void WriteToFileProfessors(string fileName, List<Professor> list, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 103));
                writer.WriteLine($"| {"Modulio pavadinimas",25} | {"Pavardė",25} | {"Vardas",25} | {"Kreditų kiekis",15} |");
                writer.WriteLine(new string('-', 103));
                foreach (Professor s in list)
                {
                    writer.WriteLine(s.ToString());
                }
                writer.WriteLine(new string('-', 103));
            }
        }

        /// <summary>
        /// Writes a list of professor workloads to a file with a header.
        /// </summary>
        /// <param name="fileName">The file to write to.</param>
        /// <param name="list">List of professor workloads.</param>
        /// <param name="header">Header text.</param>
        public static void WriteToFileWorkLoads(string fileName, List<ProfWorkLoad> list, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 75));
                writer.WriteLine($"| {"Vardas",25} | {"Pavardė",25} | {"Grupė",15} |");
                writer.WriteLine(new string('-', 75));
                foreach (ProfWorkLoad s in list)
                {
                    writer.WriteLine(s.ToString());
                }
                writer.WriteLine(new string('-', 75));
            }
        }

        /// <summary>
        /// Writes filtered professor classes to a file with a header.
        /// </summary>
        /// <param name="fileName">The file to write to.</param>
        /// <param name="listintList">List of filtered professor classes.</param>
        /// <param name="header">Header text.</param>
        public static void WriteToFileAfterFilter(string fileName, List<ProfClassesList> listintList, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 103));
                writer.WriteLine($"| {"Modulio pavadinimas",25} | {"Pavardė",25} | {"Vardas",25} | {"Grupė",15} |");
                writer.WriteLine(new string('-', 103));
                for (int i = 0; i < listintList.Count(); i++)
                {
                    ProfClassesList profClass = listintList[i];
                    for (int j = 0; j < profClass.Count(); j++)
                    {
                        writer.WriteLine(profClass.GetClass(j).ToString());
                    }
                }
                writer.WriteLine(new string('-', 103));
            }
        }
    }
}