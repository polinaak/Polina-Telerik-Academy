using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Matrix<T>
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private T[,] matrix;
        int rows, cols;

        //Constructor
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.matrix = new T[rows, cols];
        }

        //Indexer
        public T this[int row, int col]
        {
            get
            {
                if (row < this.matrix.GetLength(0) && col < this.matrix.GetLength(1))
                {
                    return this.matrix[row, col];
                }
                else
                {
                    throw new IndexOutOfRangeException("The row or col is out of range!");
                }
            }
            set
            {
                if (row < this.matrix.GetLength(0) && col < this.matrix.GetLength(1))
                {
                    this.matrix[row, col] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The row or col is out of range!");
                }
            }
        }

        //Overloading operators

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> resultMatrix = new Matrix<T>(matrix1.rows, matrix1.cols);
            if (matrix1.rows == matrix2.rows && matrix1.cols == matrix2.cols)
            {
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.cols; j++)
                    {
                        resultMatrix[i, j] = (dynamic)matrix1[i, j] + (dynamic)matrix2[i, j];
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new ArgumentException("The matrixes are with different rows or cols!");
            }
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> resultMatrix = new Matrix<T>(matrix1.rows, matrix1.cols);
            if (matrix1.rows == matrix2.rows && matrix1.cols == matrix2.cols)
            {
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.cols; j++)
                    {
                        resultMatrix[i, j] = (dynamic)matrix1[i, j] - (dynamic)matrix2[i, j];
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new ArgumentException("The matrixes are with different rows or cols!");
            }
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> resultMatrix = new Matrix<T>(matrix1.rows, matrix1.cols);
            if (matrix1.cols == matrix2.rows)
            {
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.cols; j++)
                    {
                        for (int m = 0; m < matrix1.cols; m++)
                        {
                            resultMatrix[i, j] += (dynamic)matrix1[i, m] * (dynamic)matrix2[m, j];
                        }
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new ArgumentException("The matrixes can`t be multiplied!");
            }
        }

        //check for non-zero elements
        public static Boolean operator true(Matrix<T> matrix)
        {

            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static Boolean operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(matrix[i, j] + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
          