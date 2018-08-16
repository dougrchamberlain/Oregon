using System;
using System.Collections.Generic;
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
        void Check();
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

    public class Temperature : Enumeration
    {

        public static Temperature Freezing = new Temperature(1, "Freezing");
        public static Temperature Cool = new Temperature(2,"Cool");
        public static Temperature Warm = new Temperature(3, "Warm");
        public static Temperature Hot = new Temperature(4, "Hot");
        public static Temperature Scorching = new Temperature(5, "Scorching");

        protected Temperature() { }

        public Temperature(int id, string name)
            : base(id, name)
        {

        }

        public static IEnumerable<Temperature> List()
        {
            return new[] { Freezing,Cool,Warm,Hot,Scorching };
        }

    }

    public class Weather : Behavior
    {

        public float Temp = 1.0F;

        public void Start()
        {
            Temp = 72;
        }

        public void Update()
        {
            

            Temp = (new Random().Next(1,160) / Temp) * Temp;
            
            ScreenBuffer.Draw($"Current Temp {Temp - 41}",0,12);
            
        }

        private void WeatherCheck()
        {
            var roll = new Random().Next(1, 21);

            if(roll > 15)
            {
                GameState.Temp = 72;
            }

        }

    }

}
