using System;
using System.Collections.Generic;

namespace Oregon
{
    public class Player : Behavior
    {
        public double Health = 100.0;
        public int RationAmount = 5;
        public Food Food;
        public String Name;

        public void Start()
        {
            this.Name = String.IsNullOrEmpty(this.Name) ? "Gary" : this.Name;
            Food = gameObject.AddComponent<Food>();
        }

        public void Update()
        {
            Food.Take(RationAmount);

            ScreenBuffer.Draw($"Date:{UpdateService.CurrentDate.ToShortDateString()}", 20, 0);
            ScreenBuffer.Draw($"Health: {Health}", 20, 4);
        }

        public void OnKeyPress()
        {
            ScreenBuffer.Draw("Pressing a key!", 0, 30);
            this.Health -= 1;
        }

     
    }

    public class Food : Behavior
    {
        public static int Amount = 1000;

        

        public void Take(int quantity)
        {
            Amount -= quantity;
        }

        public void Update()
        {
            ScreenBuffer.Draw($"Food: {Amount}", 20, 3);
        }
    }

    public class Event : Behavior
    {
        public GameObject World;
        public List<Player> Players;

        public void Start()
        {
            this.World = GameObject.Find("World");
            this.Players = this.World.GetComponents<Player>();
        }

        public void Update()
        {
            
            if(this.Players.Count > 0)
            {
                var check = new Random().Next(1, 21);
                if (check == 1)
                {
                    var index = new Random().Next(0, this.Players.Count);                    
                    var targetPlayer = this.Players[index];
                    if (targetPlayer.Health < 50)
                    {
                        targetPlayer.Health = 0;
                        ScreenBuffer.Draw($"{targetPlayer.Name} is Dead", 0, 19);
                    }
                }
            }

        }


    }

}

