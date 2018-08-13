using System;

namespace Oregon
{
    public class Player : Behavior
    {
        public double Health = 100.0;
        public int RationAmount = 5;
        public Food Food;

        public void Start()
        {            
            Food = gameObject.AddComponent<Food>();
        }

        public void Update()
        {
            Food.Take(RationAmount);
            UpdateService.CurrentDate = UpdateService.CurrentDate.AddDays(1);
            ScreenBuffer.Draw($"Date:{UpdateService.CurrentDate.ToShortDateString()}", 20, 0);
            ScreenBuffer.Draw($"Health: {Health}", 20, 4);
        }

        public void OnKeyPress()
        {
            ScreenBuffer.Draw("Pressing a key!", 0, 30);
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


}

