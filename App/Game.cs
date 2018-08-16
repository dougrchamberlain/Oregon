using System;

namespace Oregon
{

    public class GameState : Behavior
    {        

        public static DateTime CurrentDate  = new DateTime(1848, 3, 1);
        public static SeasonType CurrentSeason;
        public static int SeasonPenalty;
        public static bool IsStorming = false;
        public static bool isNextDay = true;
        public float newTemp;
       
        public void Awake()
        {
            gameObject.AddComponent<GameState>();
        }
        public void Start()
        {
            CurrentDate = new DateTime(1848, 2, 1);
            CurrentSeason = SeasonType.FromDate(CurrentDate);
             newTemp = CurrentSeason.Temp;
        }

        public void Update()
        {
            var newDate = CurrentDate.AddHours(1);
            if(newDate.DayOfYear > CurrentDate.DayOfYear) // don't keep evaluating this until its really a new day.
            {
                newTemp = CurrentSeason.Temp;
                CurrentSeason = SeasonType.FromDate(CurrentDate);
                isNextDay = true;
            }
            else
            {
                isNextDay = false;
            }
           
            ScreenBuffer.Draw($"Date:{CurrentDate.ToShortDateString()}", 20, 0);
            ScreenBuffer.Draw($"Season: {CurrentSeason.DisplayName}, Temp: {newTemp}", 20, 1);
            ScreenBuffer.Draw($"Season Penalty: {SeasonPenalty}", 20, 2);

            CurrentDate = newDate;

            
        }

        


    }
}

