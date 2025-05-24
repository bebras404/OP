using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5.Lists
{
	public class ProfClassesList
	{
		private List<Student> Classes;
		private string ClassName { get; set; }

        private Professor Professor { get; set; }

        public ProfClassesList(string className, List<Student> afterFilter, string Name, string LastName) 
		{
            this.Professor = new Professor(LastName, Name);
            Classes = afterFilter;
            this.ClassName = className;
        }

        public void AddClass(Student newClass)
        {
            Classes.Add(newClass);
        }

        public Student GetClass(int index)
        {
            return Classes[index];
        }

        public int Count()
        {
            return Classes.Count;
        }

        public string GetClassName()
        {
            return ClassName;
        }   

        public string GetProffessorName()
        {
            return Professor.FirstName + " " + Professor.LastName;
        }

    }
}