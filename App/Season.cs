using System;
using System.Collections.Generic;

namespace Oregon
{

    public abstract class SeasonType : Enumeration
    {
        public abstract float Temp { get; }


        private class WinterType : SeasonType
        {

            public WinterType() : base(0, "Winter") { }

            public override float Temp { get => new Random().Next(0, 50); }
        }
        private class SpringType : SeasonType
        {
            public SpringType() : base(0, "Spring") { }

            public override float Temp { get => new Random().Next(30, 80); }
        }

        private class SummerType : SeasonType
        {
            public SummerType() : base(0, "Summer") { }

            public override float Temp { get => new Random().Next(60, 110); }
        }
        private class FallType : SeasonType
        {
            public FallType() : base(0, "Fall") { }

            public override float Temp { get => new Random().Next(30, 85); }
        }

        public static SeasonType Winter = new WinterType();
        public static SeasonType Spring = new SpringType();
        public static SeasonType Summer = new SummerType();
        public static SeasonType Fall = new FallType();

        private SeasonType() { }
        private SeasonType(int value, string displayName) : base(value, displayName) { }

        public static SeasonType FromDate(DateTime Date)
        {
            SeasonType _season;
            if (Date.Month < 4)
            {
                _season = Date.Day > 20 && Date.Month == 3 ? SeasonType.Spring : SeasonType.Winter;
            }
            else if (Date.Month > 3 && Date.Month < 7)
            {
                _season = Date.Day > 20 && Date.Month == 6 ? SeasonType.Summer : SeasonType.Spring;
            }
            else if (Date.Month > 6 && Date.Month < 10)
            {
                _season = Date.Day > 20 && Date.Month == 9 ? SeasonType.Fall : SeasonType.Summer;
            }
            else
            {
                _season = Date.Day > 20 && Date.Month == 12 ? SeasonType.Winter : SeasonType.Fall;
            }

            return _season;
        }
    }
}
