using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SchoolHierarchy
{
    class Discipline
    {
        //Field
        private string classDiscipline;
        private int countLectures;
        private int countExercises;

        //Constructor
        public Discipline(string discipline, int countLectures, int countExercises)
        {
            this.classDiscipline = discipline;
            this.countLectures = countLectures;
            this.countExercises = countExercises;
        }
        //Properties
        public string ClassDiscipline
        {
            get { return this.classDiscipline; }
            set
            {
                //check if the input is correct
                foreach (var letter in this.classDiscipline)
                {
                    if (!(char.IsLetter(letter) || letter == ' '))
                    {
                        throw new ArgumentException("The name of discipline should contain only letters ans spaces.");
                    }
                }

                if (this.classDiscipline.Length < 2)
                {
                    throw new ArgumentException("The lenght of the string must be 2 or more symbols.");
                }

                this.classDiscipline = value;
            }
        }

        public int CountLectures
        {
            get { return this.countLectures; }
            set
            {
                if (countLectures < 1)
                {
                    throw new ArgumentException("The count of lectures must at least 1!");
                }

                this.countLectures = value;
            }
        }

        public int CountExercises
        {
            get { return this.countExercises; }
            set
            {
                if (countExercises < 1)
                {
                    throw new ArgumentException("The count of exercises must be at least 1!");
                }

                this.countExercises = value;
            }
        }
    }
}
