using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5
{
	public class StudList : IEnumerable<Student>
    {

		private List<Student> Classes;
        private string FacultyName { get; set; } = string.Empty;

		public StudList(string facultyName) 
		{
			Classes = new List<Student>();
            this.FacultyName = facultyName;
        }

		public StudList()
        {
            Classes = new List<Student>();
        }

        public string GetFaculty() 
		{
            return FacultyName;
        }

        public void AddClass(Student newClass) 
        {
            Classes.Add(newClass);
        }

        public void RemoveClass(Student oldClass) 
        {
            Classes.Remove(oldClass);
        }

        public Student GetClass(int index) 
        {
            return Classes[index];
        }

        public int Count()
        {
            return Classes.Count;
        }

        public int CountStudents(string cn) 
        {
            return Classes.Count(s => s.ClassName == cn);
        }

        public List<Student> GetStudentsByClass(string className)
        {
            return Classes.Where(s => s.ClassName == className).ToList();
        }

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