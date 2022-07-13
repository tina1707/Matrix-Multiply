using System;

/* 
 * Программа реализует умножение математических матриц. 
 * Размерность массивов задаётся пользователем. 
 * Размерность массивов должна быть таковой, чтобы обеспечить возможность умножения этих матриц. 
 * На это ограничение выполняется проверка.
 * При прохождении проверки массив заполняется данными, полученными от пользователя.
 * Результат умножения матриц выводится на экран
 */

namespace Matrix
{
    internal class Program
    {
        /// <summary>
        /// Проверка согласованности матриц
        /// </summary>
        /// <param name="column1"></param>
        /// <param name="row2"></param>
        /// <returns>True - матрицы согласованы, false - матрицы не согласованы</returns>
        static bool CheckConsistence(int column1, int row2)
        {
            return column1 == row2;
        }

        static (int row1, int row2, int column1, int column2) InputInterface()
        {
            Console.Write("Введите количество строк первого массива: ");
            int row1 = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов первого массива: ");
            int column1 = int.Parse(Console.ReadLine());

            Console.Write("Введите количество строк второго массива: ");
            int row2 = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов второго массива: ");
            int column2 = int.Parse(Console.ReadLine());
            return (row1, row2, column1, column2);
        }

        /// <summary>
        /// Заполнение матрицы полученными от пользователя значениями
        /// </summary>
        /// <param name="array"></param>
        static void Fill(ref int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"Укажите элемент на {i}й строке и {j} столбце: ");
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
        }

        /// <summary>
        /// Вывод матрицы на экран консоли
        /// </summary>
        /// <param name="array"></param>
        static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write($"{array[i, j],-4} ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод, реализующий умножение матриц
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns>Двумерный массив, являющийся результатом умножения массивов array1 и array2</returns>
        static int[,] Multiply(int[,] array1, int[,] array2)
        {
            int[,] array = new int[array1.GetLength(0), array2.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    for (int k = 0; k < array1.GetLength(1); k++)
                        array[i, j] += array1[i, k] * array2[k, j];
            return array;
        }


        static void Main(string[] args)
        {
            var inputData = InputInterface();
            int row1 = inputData.row1,
                row2 = inputData.row2,
                column1 = inputData.column1,
                column2 = inputData.column2;

            bool checkConsistence = CheckConsistence(column1, row2);

            while (!checkConsistence)
            {
                Console.WriteLine("Введены некорректные данные. Попробуйте снова.\nЧтобы можно было умножить две матрицы, " +
                    "количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
                inputData = InputInterface();
                row1 = inputData.row1;
                row2 = inputData.row2;
                column1 = inputData.column1;
                column2 = inputData.column2;
                checkConsistence = CheckConsistence(column1, row2);
            }

            int[,] array1 = new int[row1, column1],
                   array2 = new int[row2, column2];

            Console.WriteLine("Заполните значениями первый массив:");
            Fill(ref array1);
            Console.WriteLine("Заполните значениями второй массив:");
            Fill(ref array2);

            Console.WriteLine("Матрица №1:");
            Print(array1);
            Console.WriteLine("Матрица №2:");
            Print(array2);

            int[,] arrayMultiplied = Multiply(array1, array2);

            Console.WriteLine("Результат умножения:");
            Print(arrayMultiplied);

            Console.ReadKey();


        }
    }
}
