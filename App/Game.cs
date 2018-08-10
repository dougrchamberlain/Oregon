using System;

namespace Oregon
{
    public static class GameStateService
    {
        public static WeatherType CurrentWeather { get; set; }
        public static Season CurrentSeason { get; set; }
        public static DateTime CurrentDate { get; set; }
       
    }

    public class Game : GameObject
    {
       

        private object _options { get; set; }

        public DateTime CurrentDate = DateTime.Now;

        public void Update()
        {
           
           // ScreenBuffer.Draw($"WEATHER:{GameStateService.CurrentWeather}", 0, 0);
           // ScreenBuffer.Draw($"SEASON:{GameStateService.CurrentSeason}", 0, 0);
            var result = WeatherService.GetWeather(WeatherService.GetSeason(this.CurrentDate.AddDays(1)));

            //ScreenBuffer.Draw(this.CurrentDate.ToShortDateString(), 1, 1);
            //ScreenBuffer.Draw(result.ToString(), 1, 2);

            //System.Threading.Thread.Sleep(1000);

            ListStats();
        }

        public void ListStats()
        {
            ScreenBuffer.Draw(@"foo
foo2
", 1, 1);


        }


    }


}

