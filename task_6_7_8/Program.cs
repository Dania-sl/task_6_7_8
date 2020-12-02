using System;
using System.Text;

namespace task_6
{
    class Massif
    {
        int rows;
        int columns;
        int[][] array;
        int key;


        public int[][] CheckElemet()
        {
            Console.WriteLine("Enter the number of rows in the array!");
            String rowsString = Console.ReadLine();
            while (!int.TryParse(rowsString, out rows) || rows < 1)
            {
                Console.WriteLine("Enter correct value, type int!");
                rowsString = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of columns in the array!");
            String columnsString = Console.ReadLine();
            while (!int.TryParse(columnsString, out columns) || columns < 1)
            {
                Console.WriteLine("Enter correct value, type int!");
                columnsString = Console.ReadLine();
            }
            return FillingArray(rows, columns);
        }
        public int[][] FillingArray(int rows, int columns)
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
            return PrintArray(array, rows, columns);
        }
        public int[][] PrintArray(int [][] array, int rows, int columns )
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
            return array;
        }
        public StringBuilder EnteringKey()
        {
            Console.WriteLine("Enter searching key!");
            String keyString = Console.ReadLine();
            while (!int.TryParse(keyString, out key))
            {
                Console.WriteLine("Enter correct value, type int!");
                keyString = Console.ReadLine();
            }
            return SearchKey(key);
        }
        public StringBuilder SearchKey(int key)
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
            return listIndex;
        }

        public double[] MidElement()
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
            return midValue;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Massif massif = new Massif();
            massif.CheckElemet();
            Console.WriteLine(massif.EnteringKey());
            Console.Write(string.Join(' ', massif.MidElement()));

        }
    }
}
