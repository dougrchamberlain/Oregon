using System;

namespace Oregon
{
    public class Player : GameObject
    {
        public double Health = 100.0;
        public int RationAmount = 5;
        public DateTime CurrentDate;
        public Food Food;

        public void Start()
        {
            CurrentDate = new DateTime(1848, 3, 1);
            Food = GetComponent<Food>();
        }

        public void Update()
        {
            Food.Take(RationAmount);
            CurrentDate = CurrentDate.AddDays(1);
            ScreenBuffer.Draw($"Date:{CurrentDate.ToShortDateString()}", 20, 0);
            ScreenBuffer.Draw($"Health: {Health}", 20, 4);
        }

        public void OnKeyPress()
        {
        }

     
    }

    public class Food : GameObject
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

