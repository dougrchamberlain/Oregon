namespace Oregon
{
    public class Food : Behavior
    {
        public static int Amount = 1000;

        public Food() { }

        public void Take(int quantity)
        {
            if (GameState.isNextDay)
            {
                Amount -= quantity;
            }
            
        }

        public void Update()
        {
            ScreenBuffer.Draw($"Food: {Amount}", 0, 19);
        }
    }

}

