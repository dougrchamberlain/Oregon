using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Oregon
{
    public class Wagon : Behavior
    {
        public Weather Weather;
        public float MilesTraveled = 0F;
        
        public void Start()
        {
            Weather = GameObject.Find("World").GetComponent<Weather>();
            this.gameObject.AddComponent<Oxen>();
        }
        public void Update()
        {
            Travel();
            ScreenBuffer.Draw($"{MilesTraveled:###,###,###}", 0, 30);
        }

        public void OnKeyPress()
        {
            this.gameObject.AddComponent<Oxen>();
        }

        private void Travel()
        {
            System.Threading.Thread.Sleep(1000);
            MilesTraveled += Oxen.MaxDistancePossible;
        }


        
    }

    public class Oxen : Behavior
    {
        private static BlockingCollection<Oxen> team = new BlockingCollection<Oxen>();
       

        private float MismatchedYolkFactor = 0.15F;
        private bool isMissing = false;
        private bool isAlive = true;

        public float BaseMileage = 2.75F;
        public float MileageContribution = 0.0F;
        public static float MaxDistancePossible = 0.0F;

        public Oxen()
        {
            team.TryAdd(this,-1);
        }



        public void Update()
        {
            CalculatePullFactor();
            ScreenBuffer.Draw($"You have {team.Count} oxen. Max Team Daily Mileage {MaxDistancePossible}",0,16);
        }
      

        private void CalculatePullFactor()
        {
            var unmatchedTeamFactor = 1 + (team.Count % 2) * MismatchedYolkFactor;
            ScreenBuffer.Draw($"UnmatchedteamFactor: {unmatchedTeamFactor}", 5,10);


            MileageContribution = isAlive ?  BaseMileage / unmatchedTeamFactor : 0;

            int index = 0;
            float sum = 0;
            foreach(var o in team)
            {

                if (o.isAlive && !o.isMissing)
                {
                    sum += o.MileageContribution;
                }
                index++;
            }

            MaxDistancePossible = sum;
            
        }

        

        
        
    }
}

