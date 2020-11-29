using System;
using System.Text;

namespace task_6
{
    class matrix
    {
        int rows;
        int columns;
        int[][] array;
        int key;


        public void CheckElemet()
        {
            Console.WriteLine("Enter the number of rows in the array!");
            String rowsString = Console.ReadLine();
            while (!int.TryParse(rowsString, out rows))
            {
                Console.WriteLine("Enter correct value, type int!");
                rowsString = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of columns in the array!");
            String columnsString = Console.ReadLine();
            while (!int.TryParse(columnsString, out columns))
            {
                Console.WriteLine("Enter correct value, type int!");
                columnsString = Console.ReadLine();
            }
        }
        public void FillingArray()
        {
            array = new int[rows][];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                array[i] = new int[columns];

                for (int j = 0; j < columns; j++)
                {
                    array[i][j] = random.Next(41);
                }
            }
        }
        public void PrintArray()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void enteringKey()
        {
            Console.WriteLine("Enter searching key!");
            String keyString = Console.ReadLine();
            while (!int.TryParse(keyString, out key))
            {
                Console.WriteLine("Enter correct value, type int!");
                keyString = Console.ReadLine();
            }
        }
        public void SearchKey()
        {
            StringBuilder listIndex = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                  
                    if (array[i][j] == key)
                    {
                        listIndex.Append($"[{i}][{j}] ");
                    }
                }
            }
            Console.Write(listIndex);
        }

        public void midElement()
        {
            double[] midValue = new double[array.Length]; ;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    midValue[i] += array[i][j];
                }
            }
            for (int i = 0; i < rows; i++)
            {
                midValue[i] = midValue[i] / columns;
            }
            Console.Write(string.Join(' ', midValue));
        }
    }
    class Program
    {
      

            static void Main(string[] args)
        {
            matrix matrix = new matrix();
            matrix.CheckElemet();
            matrix.FillingArray();
            matrix.PrintArray();
            matrix.enteringKey();
            matrix.SearchKey();
            Console.WriteLine();
            matrix.midElement();

        }
    }
}
