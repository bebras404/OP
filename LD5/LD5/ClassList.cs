using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5
{
	public class ClassList<T> : IEnumerable<T>
    {

		private List<T> Classes;
        private string FacultyName { get; set; } = string.Empty;

		public ClassList(string facultyName) 
		{
			Classes = new List<T>();
            this.FacultyName = facultyName;
        }

		public ClassList()
        {
            Classes = new List<T>();
        }

        public string GetFaculty() 
		{
            return FacultyName;
        }

        public void AddClass(T newClass) 
        {
            Classes.Add(newClass);
        }

        public void RemoveClass(T oldClass) 
        {
            Classes.Remove(oldClass);
        }

        public T GetClass(int index) 
        {
            return Classes[index];
        }

        public int Count()
        {
            return Classes.Count;
        }

        /// <summary>
        /// Allows looping through the real estates.
        /// </summary>
        /// <returns>Enumerator for real estates.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in Classes)
            {
                yield return element;
            }
        }
        /// <summary>
        /// Allows looping through the real estates.
        /// </summary>
        /// <returns>Enumerator for real estates.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}