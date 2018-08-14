using System;

namespace Oregon
{
    public class Wagon : Behavior
    {
        private int _distanceTraveled;

        public int DistanceTraveled { get { return this._distanceTraveled; } }
        public bool HasOxen { get; set; }
        public bool IsOkay { get; set; }
        public bool StartTravel { get; set; } = false;

        public void Start()
        {
            this.HasOxen = true;
            this.IsOkay = true;
        }
        public void Update()
        {
            if (this.StartTravel)
            {
                this.Travel();
            }
            //ScreenBuffer.Draw($"Miles Traveled {this._distanceTraveled:#000000}", 0, 30);
        }

        public void OnKeyPress()
        {
            if (InputManager.KeyInfo.Key == ConsoleKey.Spacebar)
            {
                this.StartTravel = !this.StartTravel;
               
            }
        }

        private void Travel()
        {
            if (this.HasOxen && this.IsOkay)
            {
                this._distanceTraveled++;
            }
            //some how factor in the number of oxen also weather and terrain. and health of family and weight of wagon.
            
          
        }
    }


}

