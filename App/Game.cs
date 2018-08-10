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

        public void Update()
        {
           
            ScreenBuffer.Draw($"WEATHER:{GameStateService.CurrentWeather}", 0, 0);
            ScreenBuffer.Draw($"SEASON:{GameStateService.CurrentSeason}", 0, 0);
            new TempuratureFactor().Roll(1000000);

            System.Threading.Thread.Sleep(1000);
        }


    }


}

