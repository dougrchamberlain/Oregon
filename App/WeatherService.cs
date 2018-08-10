using System;
using System.Linq;
using System.Reflection;

namespace Oregon
{
    public enum WeatherType
    {
        Sunny = 1,
        Cloudy = 2,
        Raining = 3,
        Thunderstorm = 4,
        Snowing = 5,
        Blizzard = 6
    }

   
    public interface ICheckable
    {
        int Roll(int min, int max);
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

    public enum TemperatureFactor {
            Freezing = 0,
            Cool = 1,
            Warm = 2,
            Hot = 3,
            Scorching = 4
        }

    public static class WeatherService
    {
       

        public static TemperatureFactor GetWeather(Season season)
        {           
            var tFactor = season.Check();
            return tFactor;
        }

        public static Season GetSeason(DateTime Date)
        {
            Season season = Season.Winter;

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
