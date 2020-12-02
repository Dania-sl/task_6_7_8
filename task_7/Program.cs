using System;
using System.IO;
using System.Linq;

namespace task_7
{
    public enum WeatherType
    {
        noDefine,
        rain,
        short_rain,
        thunderstorm,
        snow,
        fog,
        sunny,
        darkly
    }
    static class StaticValue
    {
        public static int monthDay = 31;
        public static string path = @"Day.txt";
    }
    class WeatherParametersDay
    {

        public WeatherType WeatherType { get; private set; }
        public double AverageTemperatureDay { get; private set; }
        public double AverageTemperatureNight { get; private set; }
        public double AverageAtmosphericPressure { get; private set; }
        public double Precipitation { get; private set; }
        public WeatherParametersDay(double averageTemperatureDay, double averageTemperatureNight, double averageAtmosphericPressure, double precipitation, int weatherType)
        {
            WeatherType = (WeatherType)weatherType;
            AverageTemperatureDay = averageTemperatureDay;
            AverageTemperatureNight = averageTemperatureNight;
            AverageAtmosphericPressure = averageAtmosphericPressure;
            Precipitation = precipitation;
        }
    }


    class WeatherDays
    {
        private WeatherParametersDay[] WeatherArray { get; }

        public WeatherDays(WeatherParametersDay[] WeatherArray) => this.WeatherArray = WeatherArray;
        private int CountDays(params WeatherType[] weatherType)
        {
            int daysInMonth = 0;
            foreach (WeatherParametersDay day in WeatherArray)
                if (weatherType.Contains(day.WeatherType))
                {
                    daysInMonth += 1;
                }   

            return daysInMonth;
        }
        public int CountSunnyDays() => CountDays(WeatherType.sunny);
        public int CountNoRainDays() => CountDays(WeatherType.sunny);


        public double AverageTemperatuMonthDay()
        {
            double tempSum = 0;
            foreach (WeatherParametersDay day in WeatherArray)
            {
                tempSum += day.AverageTemperatureDay;
            }

            double avgTemp = tempSum / StaticValue.monthDay;
            return avgTemp;
        }

    }

    class Program
    {
        private static void PrintArray(int[,] daysConsoleArray)
        {
            for (int i = 0; i < daysConsoleArray.GetLength(0); i++)
            {
                for (int j = 0; j < daysConsoleArray.GetLength(1); j++)
                {
                    Console.Write(daysConsoleArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        private static string[] LineArray()
        {
            string[] line = Console.ReadLine().Split(' ');
            if (line.Length != 31)
            {
                Console.WriteLine("You enter wrong values!");
                Environment.Exit(0);
            }
            return line;
        }
        private static int[,] ReadingFromFile( ref int[,] daysFileArray)
        {
            string[] lines = File.ReadAllLines(StaticValue.path);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split(' ').Length != 31)
                {
                    Console.WriteLine($"The wrong number of elements in the {i + 1} line ");
                    Environment.Exit(0);
                }
                string[] tempArray = lines[i].Split(' ');
                for (int j = 0; j < tempArray.Length; j++) 
                while (!int.TryParse(tempArray[j], out daysFileArray[i, j]))
                {
                    Console.WriteLine("Wrong value in file!");
                    Environment.Exit(0);
                    }
            }
            PrintArray(daysFileArray);
            return ChekTypeWeatherArray(daysFileArray);
        }
        private static int[,] ReadingFromConsole( ref int[,] daysConsoleArray)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Entet line {i + 1}");
                string[] tempArray = LineArray();
                for (int j = 0; j < tempArray.Length; j++)
                    while (!int.TryParse(tempArray[j], out daysConsoleArray[i, j]))
                    {
                        Console.WriteLine("You enter wrong value!");
                    }
            }
            PrintArray(daysConsoleArray);
            return ChekTypeWeatherArray(daysConsoleArray);
        }

        private static int[,] ChekTypeWeatherArray( int[,] daysArray)
        {
            for (int i = 0; i < daysArray.GetLength(1); i++)
            {
                if (daysArray[4, i] < 0 || daysArray[4, i] > 7 || daysArray[3, i] < 0 || daysArray[2, i] < 0)
                {
                    Console.WriteLine("WE");
                    Environment.Exit(0);
                }
            }
            return daysArray;
        }


        static void Main(string[] args)
        {
            int[,] daysArray = new int[5, StaticValue.monthDay];

            Console.Write("Press k if you want use keyboard and f if you want use file ");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine("");
            if (key == ConsoleKey.K)
            {
               ReadingFromConsole(ref daysArray);
            }
            if (key == ConsoleKey.F)
            {
                ReadingFromFile(ref daysArray);
            }
            if (key != ConsoleKey.F && key != ConsoleKey.K)
            {
                Console.WriteLine("You enter wrong key");
                Environment.Exit(0);
            }


            WeatherParametersDay[] weatherParametersDays = new WeatherParametersDay[daysArray.GetLength(1)];
            for (int i = 0; i < daysArray.GetLength(1); i++)
                weatherParametersDays[i] = new WeatherParametersDay(daysArray[0, i],daysArray[1, i],daysArray[2, i], daysArray[3, i], (int)daysArray[4, i]);
            WeatherDays weatherDays = new WeatherDays(weatherParametersDays);
            Console.WriteLine($"\nNumber of sunny days: {weatherDays.CountSunnyDays()}\nThe number of days when there was precipitation: {weatherDays.CountNoRainDays()}");
            Console.WriteLine($"Average daytime temperature: {weatherDays.AverageTemperatuMonthDay()}");
        }
    }
}




