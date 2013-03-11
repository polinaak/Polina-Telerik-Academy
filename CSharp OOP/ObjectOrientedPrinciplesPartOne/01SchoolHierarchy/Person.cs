﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SchoolHierarchy
{
    public class Person
    {
        //Fields
        private string name;
        private string comment { get; set; }

        //Constructors
        public Person(string name)
        {
            this.name = name;
        }

        public Person(string name, string comment)
            :this (name)
            {
                this.comment = comment;
            }

        //Properties
        public string Name
        {
            get { return this.name; }
            set
            {
                foreach (var letter in this.name)
                {
                    if (!(char.IsLetter(letter) || letter == ' '))
                    {
                        throw new ArgumentException("Wrong name!");
                    }
                }
                if (name.Length < 2)
                {
                    throw new ArgumentException("The name can`t be less 2 letters!");
                }
                this.name = value;
            }
        }
    }
}