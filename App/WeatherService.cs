using System;
using System.Collections.Generic;

namespace Oregon
{
    public enum WeatherType
    {
        Sunny = 1,
        Cloudy = 2,
        Raining = 3,
        Thunderstorm = 4,
        Snowy = 5
    }

    public enum Season
    {
        Winter = 1,
        Spring = 2,
        Summer = 3,
        Fall = 4,


    }

    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,

    }

    public enum TempuratureFactor {
            Freezing = -3,
            Cold = -2,
            Warm = 0,
            Hot = 2,
            Scorching = 4
        }

    public static class EnumHelpers
    {
        public static List<Enum> Roll(this Enum @enum,int iterations = 1)
        {
            var list = new List<Object>();
            var values = Enum.GetValues(@enum.GetType());
            Array.Sort(values);
            var min = values.GetValue(0);
            var max = values.GetValue(values.GetUpperBound(0));

            for (var i = 0; i <= iterations; i++)
            {
               
                list.Add(Enum.ToObject(@enum.GetType(), new Random().Next((int)min, (int)max)));
            }

            return list;
        }
    }

    public static class WeatherService
    {
       

        public static WeatherType GetWeather(Season season)
        {


            switch (season)
            {                
                case Season.Winter:
                    break;
                case Season.Spring:
                    break;
                case Season.Summer:
                    break;
                case Season.Fall:
                    break;
                default:
                    break;
            }

            return WeatherType.Sunny;
        }

        public static Season GetSeason(DateTime Date)
        {
            Season season = new Season();

            switch ((Month)Date.Month)
            {
                case Month.January:
                case Month.February:
                    season = Season.Winter;
                    break;
                case Month.March:
                    season = Date.Day < 21 ? Season.Winter : Season.Spring;
                    break;

                case Month.April:
                case Month.May:
                    season = Season.Spring;
                    break;
                case Month.June:
                    season = Date.Day < 21 ? Season.Spring : Season.Summer;
                    break;

                case Month.July:                   
                case Month.August:
                    season = Season.Summer;
                    break;
                case Month.September:
                    season = Date.Day < 21 ? Season.Summer : Season.Fall;
                    break;
                case Month.October:
                case Month.November:
                    season = Season.Fall;
                    break;
                case Month.December:
                    season = Date.Day < 21 ? Season.Fall : Season.Winter;
                    break;

                default:
                    break;
            }
            return season;
        }




    }
}
