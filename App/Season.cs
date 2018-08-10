using System;
using System.Collections.Generic;

namespace Oregon
{

    public abstract class Season : Enumeration, ICheckable
    {
        protected class WinterSeason : Season
        {
            public WinterSeason()
                : base(1, "Winter") {
                         this._penalty = -4;
            }


            public override TemperatureFactor Check()
            {
                var roll = this.Roll() + this.Penalty;


                if (roll <= 10) {
                    return TemperatureFactor.Freezing;
                }
                else if (roll <= 16)
                {
                    return TemperatureFactor.Cool;
                }
                else
                {
                    return TemperatureFactor.Warm;
                }
            }
        }
        protected class SpringSeason : Season
        {
            public SpringSeason()
              : base(2, "Spring") {
                this._penalty = 0;
            }
             public override TemperatureFactor Check()
            {
                var roll = this.Roll() + this.Penalty;


                if (roll == 1) {
                    return TemperatureFactor.Freezing;
                }
                else if( roll <= 3)
                {
                    return TemperatureFactor.Hot;
                }
                else if (roll <= 16)
                {
                    return TemperatureFactor.Cool;
                }
                else
                {
                    return TemperatureFactor.Warm;
                }
            }
        }
        protected class SummerSeason : Season
        {
            public SummerSeason()
              : base(3, "Summer") {
                this._penalty = -4;
            }

             public override TemperatureFactor Check()
            {
                var roll = this.Roll() + this.Penalty;


                if (roll == 1) {
                    return TemperatureFactor.Scorching;
                }
                else if( roll <= 3)
                {
                    return TemperatureFactor.Cool;
                }
                else if (roll <= 16)
                {
                    return TemperatureFactor.Hot;
                }
                else
                {
                    return TemperatureFactor.Warm;
                }
            }
        }
        protected class FallSeason : Season
        {
            public FallSeason()
            : base(4, "Fall") {
                this._penalty = -1;
            }
              public override TemperatureFactor Check()
            {
                var roll = this.Roll() + this.Penalty;


                if (roll == 1) {
                    return TemperatureFactor.Freezing;
                }
                else if( roll <= 3)
                {
                    return TemperatureFactor.Hot;
                }
                else if (roll <= 16)
                {
                    return TemperatureFactor.Cool;
                }
                else
                {
                    return TemperatureFactor.Warm;
                }
            }
        }

        public static Season Winter = new WinterSeason();
        public static Season Spring = new SpringSeason();
        public static Season Summer = new SummerSeason();
        public static Season Fall = new FallSeason();

        public int Penalty {get {return this._penalty;} }
        protected int _penalty;

        protected Season() {}

        public Season(int id, string name)        
            : base(id, name)
        {
   
        }
        
        public static IEnumerable<Season> List()
        {
            return new[] { Winter, Spring, Summer, Fall };
        }

        public abstract TemperatureFactor Check();

        public int Roll(int min = 1, int max = 20)
        {
            return new Random().Next(min, max + 1);
        }
    }
}
