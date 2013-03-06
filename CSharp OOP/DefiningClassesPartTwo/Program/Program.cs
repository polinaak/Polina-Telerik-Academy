using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main()
        {
            //Initialization
            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            Matrix<int> matrix2 = new Matrix<int>(2, 2);
            Matrix<float> mtrx3 = new Matrix<float>(2, 2);

            matrix1[0, 0] = 2;
            matrix1[0, 1] = 1;
            matrix1[1, 0] = -6;
            matrix1[1, 1] = 0;
                
            matrix2[0, 0] = 3;
            matrix2[0, 1] = 2;
            matrix2[1, 0] = 3;
            matrix2[1, 1] = 1;

            Console.WriteLine(matrix1);
            //Checking for non-zero elements
            if (matrix1)
            {
                Console.WriteLine("There is no zero inside");
            }
            else Console.WriteLine("There is at least one zero inside\n");

            //Testing methods
            Console.WriteLine("Sum of the two matrices");
            Console.WriteLine(matrix1 + matrix2);
            Console.WriteLine("Substraction of the two matrices");
            Console.WriteLine(matrix1 - matrix2);
            Console.WriteLine("Multiplication of the two matrices");
            Console.WriteLine(matrix1 * matrix2);
        }
    }
}
