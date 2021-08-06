using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_1
{
    public class Matrix
    {
        private double[,] matrix;
        /// <summary>Количество столбцов матрицы</summary>
        private int n;
        /// <summary>Количество строк матрицы</summary>
        private int m;
        
        /// <summary> Размерность строки матрицы </summary>
        public int RowsCount
        {
            get { return matrix.GetLength(0); }
        }

        /// <summary> Размерность столбца матрицы </summary>
        public int ColumnsCount
        {
            get { return matrix.GetLength(1); }
        }

        /// <summary>Создание нулевой квадратной матрицы</summary>
        /// <param name="n">Размерность матрицы</param>
        public Matrix(int n)
        {
            //this.n = n;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = 0;
        }
        
        /// <summary>Создание нулевой матрицы</summary>
        /// <param name="n">Количество столбцов</param>
        /// <param name="m">Количество строк</param>
        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = 0;
        }

        public double this [int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        /// <summary>Единичная матрица</summary>
        /// <param name="n">Размерность матрицы</param>
        public Matrix EMatrix(int n)
        {
            Matrix matrix = new Matrix(n);
            //this.n = n;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                    if (i == j) matrix[i, j] = 1;
                }
            return matrix;  
        }

        /// <summary>Сложение двух матриц</summary>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix = new Matrix(matrix1.ColumnsCount);
            for (int i = 0; i < matrix1.ColumnsCount; i++)
            {
                for (int j = 0; j < matrix1.RowsCount; j++)
                {
                    matrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return matrix;
        }

        /// <summary>Разность двух матриц</summary>
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix = new Matrix(matrix1.ColumnsCount);
            for (int i = 0; i < matrix1.ColumnsCount; i++)
            {
                for (int j = 0; j < matrix1.RowsCount; j++)
                {
                    matrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return matrix;
        }

        /// <summary>Умножение матрицы на матрицу/вектор</summary>
        /// <param name="matrix1">Матрица слева</param>
        /// <param name="matrix2">Матрица или вектор справа</param>
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            // m1_n1 * m2_n2.   n1 = m2
            Matrix matrix = new Matrix(matrix1.ColumnsCount);
            int m1 = matrix1.RowsCount;
            int n1 = matrix1.ColumnsCount;
            int m2 = matrix2.RowsCount;
            int n2 = matrix2.ColumnsCount;
            double tmp = 0;
            // ONLY if n1 = m2
            for (int i = 0; i < m1; i++)
                for (int j = 0; j < n1; j++)
                {
                    tmp = 0;
                    for (int k = 0; k < n1; k++)
                        tmp += matrix1[i, k] * matrix2[k, j];
                    matrix[i, j] += matrix1[i, j] * matrix2[i, j];
                }
            return matrix;
        }

        //public Matrix SwapStrokes(int i, int j)
        //{
        //
        //}
        //
        //public Matrix SwapColumns(int i, int j)
        //{
        //
        //}
    }
}
