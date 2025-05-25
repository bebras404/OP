using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5.Lists
{
    /// <summary>
    /// Stores a list of students for a professor's class.
    /// Keeps the class name and professor information.
    /// </summary>
    public class ProfClassesList
    {
        /// <summary>
        /// List of students in the class.
        /// </summary>
        private List<Student> Classes;

        /// <summary>
        /// Name of the class.
        /// </summary>
        private string ClassName { get; set; }

        /// <summary>
        /// Professor who teaches the class.
        /// </summary>
        private Professor Professor { get; set; }

        /// <summary>
        /// Creates a new ProfClassesList with class name, students, and professor's name.
        /// </summary>
        /// <param name="className">Name of the class</param>
        /// <param name="afterFilter">List of students</param>
        /// <param name="Name">Professor's first name</param>
        /// <param name="LastName">Professor's last name</param>
        public ProfClassesList(string className, List<Student> afterFilter, string Name, string LastName)
        {
            this.Professor = new Professor(LastName, Name);
            Classes = afterFilter;
            this.ClassName = className;
        }

        /// <summary>
        /// Adds a student to the class.
        /// </summary>
        /// <param name="newClass">Student to add</param>
        public void AddClass(Student newClass)
        {
            Classes.Add(newClass);
        }

        /// <summary>
        /// Gets a student by index.
        /// </summary>
        /// <param name="index">Index of the student</param>
        /// <returns>Student at the given index</returns>
        public Student GetClass(int index)
        {
            return Classes[index];
        }

        /// <summary>
        /// Gets the number of students in the class.
        /// </summary>
        /// <returns>Count of students</returns>
        public int Count()
        {
            return Classes.Count;
        }

        /// <summary>
        /// Gets the class name.
        /// </summary>
        /// <returns>Class name</returns>
        public string GetClassName()
        {
            return ClassName;
        }

        /// <summary>
        /// Gets the professor's full name.
        /// </summary>
        /// <returns>Professor's first and last name</returns>
        public string GetProffessorName()
        {
            return Professor.FirstName + " " + Professor.LastName;
        }

    }
}