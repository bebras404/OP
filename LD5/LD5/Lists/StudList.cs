using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5
{
    /// <summary>
    /// Stores a list of students for a faculty.
    /// Lets you add, remove, and find students by class.
    /// </summary>
    public class StudList : IEnumerable<Student>
    {

        private List<Student> Classes;
        private string FacultyName { get; set; } = string.Empty;

        /// <summary>
        /// Makes a new student list for a faculty.
        /// </summary>
        /// <param name="facultyName">Name of the faculty</param>
        public StudList(string facultyName)
        {
            Classes = new List<Student>();
            this.FacultyName = facultyName;
        }

        /// <summary>
        /// Makes a new empty student list.
        /// </summary>
        public StudList()
        {
            Classes = new List<Student>();
        }

        /// <summary>
        /// Gets the faculty name.
        /// </summary>
        /// <returns>Faculty name</returns>
        public string GetFaculty()
        {
            return FacultyName;
        }

        /// <summary>
        /// Adds a student to the list.
        /// </summary>
        /// <param name="newClass">Student to add</param>
        public void AddClass(Student newClass)
        {
            Classes.Add(newClass);
        }

        /// <summary>
        /// Removes a student from the list.
        /// </summary>
        /// <param name="oldClass">Student to remove</param>
        public void RemoveClass(Student oldClass)
        {
            Classes.Remove(oldClass);
        }

        /// <summary>
        /// Gets a student by index.
        /// </summary>
        /// <param name="index">Index of student</param>
        /// <returns>Student at index</returns>
        public Student GetClass(int index)
        {
            return Classes[index];
        }

        /// <summary>
        /// Gets the number of students in the list.
        /// </summary>
        /// <returns>Count of students</returns>
        public int Count()
        {
            return Classes.Count;
        }

        /// <summary>
        /// Counts students in a class.
        /// </summary>
        /// <param name="cn">Class name</param>
        /// <returns>Number of students in the class</returns>
        public int CountStudents(string cn)
        {
            return Classes.Count(s => s.ClassName == cn);
        }

        /// <summary>
        /// Gets all students in a class.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <returns>List of students in the class</returns>
        public List<Student> GetStudentsByClass(string className)
        {
            return Classes.Where(s => s.ClassName == className).ToList();
        }

        /// <summary>
        /// Gets an enumerator for the students.
        /// </summary>
        /// <returns>Enumerator for students</returns>
        public IEnumerator<Student> GetEnumerator()
        {
            return Classes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}