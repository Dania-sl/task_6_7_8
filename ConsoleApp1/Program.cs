using System;
using System.IO;
using System.Linq;
using task_7;

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
        sunly,
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
        public WeatherParametersDay(double avgDayTemp, double avgNightTemp, double avgAtmPressure, double precipitation, int weatherType)
        {
            WeatherType = (WeatherType)weatherType;
            AverageTemperatureDay = avgDayTemp;
            AverageTemperatureNight = avgNightTemp;
            AverageAtmosphericPressure = avgAtmPressure;
            Precipitation = precipitation;
        }
    }


    class WeatherDays
    {
        private readonly WeatherParametersDay[] dataWeatherArray;

        public WeatherDays(WeatherParametersDay[] dataWeatherArray) => this.dataWeatherArray = dataWeatherArray;
        private int CountDays(params WeatherType[] weatherType)
        {
            int daysInMonth = 0;
            foreach (WeatherParametersDay day in dataWeatherArray)
                daysInMonth += weatherType.Contains(day.WeatherType) ? 1 : 0;

            return daysInMonth;
        }
        public int CountSunnyDays() => CountDays(WeatherType.sunly);
        public int CountNoRainDays() => CountDays(WeatherType.snow, WeatherType.rain, WeatherType.short_rain);


        public double AverageTemperatuMonthDay()
        {
            double values = 0;
            foreach (WeatherParametersDay day in dataWeatherArray)
            {
                values += day.AverageTemperatureDay;
            }

            double avgTemp = values / StaticValue.monthDay;
            return avgTemp;
        }

    }

    class Program
    {
        private static void ReadConsole(out string[] dataStrings)
        {
            Console.WriteLine("\nВведите данные для каждого дня в отдельной строке через пробел.\n" +
                "ВАЖНО: несоблюдение правил ввода данных повлечет за собой сбой программы.");
            dataStrings = new string[Constants.DAYS_IN_MONTH];

            for (int line = 0; line < Constants.DAYS_IN_MONTH; line++)
            {
                while (true)
                {
                    Console.WriteLine($"Строка {line}:");
                    dataStrings[line] = Console.ReadLine();
                    try
                    {
                        if (dataStrings[line] == "")
                            throw new NullReferenceException();
                        break;
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        static void chekEnumArray(int[,] num)
        {
            for (int i = 0; i < num.GetLength(1); i++)
            {
                if (num[4, i] < 0 || num[4, i] > 7 || num[3, i] < 0 || num[2, i] < 0)
                {
                    Console.WriteLine("WE");
                    Environment.Exit(0);
                }
            }
        }


        static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines(StaticValue.path);
            int[,] num = new int[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    while (!int.TryParse(temp[j], out num[i, j]))
                    {
                        Console.WriteLine(" Wrong value in file!");
                    }
            }
            chekEnumArray(num);


            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    Console.Write(num[i, j] + " ");
                }
                Console.WriteLine();
            }

            WeatherParametersDay[] weatherParametersDays = new WeatherParametersDay[num.GetLength(1)];
            for (int i = 0; i < num.GetLength(1); i++)
                weatherParametersDays[i] = new WeatherParametersDay(num[0, i], num[1, i], num[2, i], num[3, i], (int)num[4, i]);
            WeatherDays weatherDays = new WeatherDays(weatherParametersDays);
            Console.WriteLine($"\nКоличество ясных дней: {weatherDays.CountSunnyDays()}\nКоличество дней, когда было дождя: {weatherDays.CountNoRainDays()}");
            Console.WriteLine($"Средняя температура: {weatherDays.AverageTemperatuMonthDay()}");
        }
    }
}




