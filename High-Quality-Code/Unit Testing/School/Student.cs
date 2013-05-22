using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class Student
    {
        public const int MIN_UNIQUE_NUMBER = 10000;
        public const int MAX_UNIQUE_NUMBER = 99999;
        private string name;
        private int uniqueNumber;
        private static List<int> listUniqueNumbers = new List<int>();

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("name can`t be empty string!");
                }

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            set
            {
                if (value < MIN_UNIQUE_NUMBER || value > MAX_UNIQUE_NUMBER)
                {
                    throw new ArgumentOutOfRangeException("Unique number is between 10000 and 99999!");
                }

                bool isUnique = CheckUniqueNumber(value);
                if (isUnique == true)
                {
                    this.uniqueNumber = value;
                }
                else
                {
                    throw new ArgumentException("There is already student with this number!");
                }
                
            }
        }

        private bool CheckUniqueNumber(int candidateUniqueNumber)
        {
            int countUniqueNumber = listUniqueNumbers.Count();
            bool isUniqueNumber = false;
            if (countUniqueNumber == 0)
            {
                listUniqueNumbers.Add(candidateUniqueNumber);
                isUniqueNumber = true;
                return isUniqueNumber;
            }
            else
            {
                for (int i = 0; i < countUniqueNumber; i++)
                {
                    if (listUniqueNumbers[i] == candidateUniqueNumber)
                    {
                        isUniqueNumber = false;
                        return isUniqueNumber;
                    }
                }

                listUniqueNumbers.Add(candidateUniqueNumber);
                isUniqueNumber = true;
                return isUniqueNumber;
            }
        }
    }
}
