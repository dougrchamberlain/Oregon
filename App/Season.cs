using System;
using System.Collections.Generic;

namespace Oregon
{

    public sealed class Season : GameObject
    {
        private SeasonNames _season;        

        public enum SeasonNames
        {
            Winter,
            Spring,
            Summer,
            Fall
        }

        public enum Penalty
        {
            Winter = -4,
            Spring = 0,
            Summer = -2,
            Fall = 0,
        }

        public SeasonNames CurrentSeason { get { return _season; } }
        public Penalty CurrentPenalty { get { return _penalty; } }
        private Penalty _penalty;

        public Player player;
        
        public void Start()
        {
            player =  GetComponent<Player>();
        }

        public void FromDate(DateTime Date)
        {           

            if (Date.Month < 4)
            {
                _season = Date.Day > 20 && Date.Month == 3 ? SeasonNames.Spring : SeasonNames.Winter;
            }
            else if (Date.Month > 3 && Date.Month < 7)
            {
                _season = Date.Day > 20 && Date.Month == 6 ? SeasonNames.Summer : SeasonNames.Spring;
            }
            else if (Date.Month > 6 && Date.Month < 10)
            {
                _season = Date.Day > 20 && Date.Month == 9 ? SeasonNames.Fall : SeasonNames.Summer;
            }
            else
            {
                _season = Date.Day > 20 && Date.Month == 12 ? SeasonNames.Winter : SeasonNames.Fall;
            }

             _penalty = Enum.Parse<Penalty>(((int)_season).ToString());
            
        }

        public void Update()
        {
            FromDate(player.CurrentDate);
            ScreenBuffer.Draw($"Season: {_season}",0,2);
        }

        
    }
}
