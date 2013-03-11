using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SchoolHierarchy
{
    class Teacher : Person
    {
        //Field
        private List<Discipline> setDisciplines {get; set;}

       //Constructors
        public Teacher(string name, List<Discipline> setDisciplines)
            : this(name, setDisciplines, null)
        { }

        public Teacher(string name, List<Discipline> setDisciplines, string comment)
            : base(name, comment)
        {
            this.setDisciplines = setDisciplines;
        }

        //Properties
        public List<Discipline> SetDisciplines
        {
            get { return this.setDisciplines; }
            set
            {
                if (setDisciplines.Count < 1)
                {
                    throw new ArgumentException("The teacher should have at least one discipline!");
                }
            }
        }
    }
}
