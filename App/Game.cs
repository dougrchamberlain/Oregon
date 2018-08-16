using System;

namespace Oregon
{

    public class GameState : Behavior
    {        

        public static DateTime CurrentDate  = new DateTime(1848, 3, 1);
        public static int Temp;
        public static Season.SeasonNames CurrentSeason;
        public static int SeasonPenalty;
       
        public void Awake()
        {
            gameObject.AddComponent<GameState>();
        }
        public void Start()
        {
            CurrentDate = new DateTime(1848, 2, 1);
        }

        public void Update()
        {
            CurrentSeason = Season.FromDate(CurrentDate);
            SeasonPenalty = (int)Enum.Parse<Season.Penalty>(Enum.GetName(typeof(Season.SeasonNames),CurrentSeason));
            ScreenBuffer.Draw($"Date:{CurrentDate.ToShortDateString()}", 20, 0);
            ScreenBuffer.Draw($"Season: {CurrentSeason}", 20, 1);
            ScreenBuffer.Draw($"Season Penalty: {SeasonPenalty}", 20, 2);
            ScreenBuffer.Draw($"Current Temp: {Temp} degrees", 20, 3);
            CurrentDate = CurrentDate.AddHours(1);

            
        }

        


    }
}

