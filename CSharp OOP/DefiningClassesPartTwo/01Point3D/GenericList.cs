using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Point3D
{
    public class GenericList<T> 
        where T : IComparable<T>
    {
        private T[] pointsList;
        int capacity = 0;
        int count = 0;

        //Constuctor
        public GenericList(int capacity)
        {
            this.capacity = capacity;
        }

        //Method
        public void Add(T element)
        {
            if (this.count < this.capacity)
            {
                if (this.capacity > this.count)
                {
                    this.pointsList[count] = element;
                    this.count++;
                }
                else
                {
                    AutoGrow(pointsList);
                    Add(element);
                }
            }
            else
            {
                throw new IndexOutOfRangeException("The index is out of range!");
            }
        }

        public T AccessByIndex(int index)
        {
            if (this.capacity > index)
            {
                return this.pointsList[index];
            }
            else
            {
                throw new IndexOutOfRangeException("The index is out of range!");
            }
        }

        public void RemoveElement(int index)
        {
            if (this.count > index)
            {
                for (int i = index; i < this.count; i++)
                {
                    this.pointsList[index] = this.pointsList[index + 1];
                }
                count--;
            }
            else
            {
                throw new IndexOutOfRangeException("The index is out of range!");
            }
        }

        public void InsertElement(int index, T element)
        {
            if (index > this.count)
            {
                if (this.capacity > this.count)
                {
                    for (int i = this.count; i > index; i--)
                    {
                        pointsList[i] = pointsList[i - 1];
                    }
                    this.pointsList[index] = element;
                    this.count++;
                }
                else
                    {
                        AutoGrow(pointsList);
                        InsertElement(index, element);
                    }
            }
            else
            {
                throw new IndexOutOfRangeException("The index is out of range!");
            }
        }

        public void Clear()
        {
            this.pointsList = new T[this.capacity];
            count = 0;
        }

        public int FindElement(T element)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (pointsList[i].CompareTo(element) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                sb.Append(this.pointsList[i]);
            }
            return sb.ToString();
        }

        public void AutoGrow(T[] previousList)
        {
            this.capacity = this.capacity*2;
            T[] pointsList = new T[capacity];
            for (int i = 0; i < this.count; i++)
            {
                this.pointsList[i] = previousList[i];
            }
        }

        public T Min()
        {
            dynamic minElement = this.pointsList[0];
            foreach (var point in pointsList)
            {
                if(minElement.CompareTo(point) < 0)
                {
                    minElement = point;
                }
            }
            return minElement;
        }

        public T Max()
        {
            dynamic maxElement = this.pointsList[0];
            foreach (var point in pointsList)
            {
                if (maxElement.CompareTo(point) > 0)
                {
                    maxElement = point;
                }
            }
            return maxElement;
        }
    }
}
